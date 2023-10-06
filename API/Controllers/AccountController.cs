using API.Contracts;
using API.Data;
using API.DTO.AccountRoles;
using API.DTO.Accounts;
using API.DTO.Employees;
using API.Repositories;
using API.Utilities.Enums;
using API.Utilities.Handler;
using API.Utilities.Hashing;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Security.Claims;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    [EnableCors]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailHandler _emailHandler;
        private readonly ITokenHandler _tokenHandler;
        public AccountController(IAccountRoleRepository accountRoleRepository, 
            IAccountRepository accountRepository,
            IEmployeeRepository employeeRepository, 
            IEducationRepository educationRepository,
            IUniversityRepository universityRepository,IRoleRepository roleRepository,
            IEmailHandler emailHandler, ITokenHandler tokenHandler)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
            _accountRoleRepository = accountRoleRepository;
            _roleRepository = roleRepository;
            _emailHandler = emailHandler;
            _tokenHandler = tokenHandler;
        }

        //login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto login)
        {
            var cekEmail = _employeeRepository.GetGuidByEmail(login.Email);
            if (cekEmail is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email Not Found"
                });
            }

            var account = _accountRepository.GetByGuid(cekEmail.Guid);
            if (account is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            bool isPasswordValid = HashingHandler.VerifyPassword(login.Password, account.Password);
            if (!isPasswordValid)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "AAccount or Password is invalid"
                });
            }

            // atur isi yang ingin dimasukan dalam isi token (Claim)
            var claims = new List<Claim>();
            claims.Add(new Claim("Email", cekEmail.Email));
            claims.Add(new Claim("FullName", string.Concat(cekEmail.FirstName + " " + cekEmail.LastName)));
            var getRoleName = from ar in _accountRoleRepository.GetAll()
                              join r in _roleRepository.GetAll() on ar.RoleGuid equals r.Guid
                              where ar.AccountGuid == account.Guid
                              select r.Name;

            
            foreach (var roleName in getRoleName)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));
            }
            // generate atau hasilkan token sesuai isi yang ditambahkan pada claim
            var generateToken = _tokenHandler.Generate(claims);

            return Ok(new ResponseOKHandler<object>("Login Berhasil",new {Token = generateToken}));
        }

        // register dengan rollback
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterNewEmployeeDto createAcc)
        {
            University toUniversity = new University();
            //var cekEmail = _employeeRepository.GetEmail(createAcc.Email);
            if (createAcc.Password != createAcc.ConfirmPassword)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to create data",
                    Error = "The password and confirmation password do not match"
                });
            }
            var cekUniv = _universityRepository.GetUniversity(createAcc.UniversityCode, createAcc.UniversityName);
            using var context = _accountRepository.GetContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                if (cekUniv is null)
                {
                    toUniversity.Guid = Guid.NewGuid();
                    toUniversity.Name = createAcc.UniversityName;
                    toUniversity.Code = createAcc.UniversityCode;
                    _universityRepository.Create(toUniversity);
                }
                else
                {
                    toUniversity = cekUniv;
                    //return Ok(new ResponseOKHandler<University>(toUniversity));
                }
                Guid newGuidd = Guid.NewGuid();
                // add employee
                Employee newEmp = createAcc;
                newEmp.Guid = newGuidd;
                newEmp.Nik = GenerateHandler.GenerateNik(_employeeRepository.GetLastNik());
                var cek = _employeeRepository.Create(newEmp);
                if (cek is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status500InternalServerError,
                        Status = HttpStatusCode.InternalServerError.ToString(),
                        Message = "Failed to create Employee",
                    });
                }


                // add Account
                Account newAccount = new Account();
                newAccount.Guid = newGuidd;
                newAccount.IsDeleted = false;
                newAccount.Otp = 0;
                newAccount.IsUsed = true;
                newAccount.ExpiredDate = DateTime.Now;
                newAccount.Password = HashingHandler.HashPassword(createAcc.Password);
                newAccount.CreatedDate = DateTime.Now;
                newAccount.ModifiedDate = DateTime.Now;
                
                var cek2 = _accountRepository.Create(newAccount);
                if (cek2 is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status500InternalServerError,
                        Status = HttpStatusCode.InternalServerError.ToString(),
                        Message = "Failed to create Acc",
                    });
                }
                // add education
                Education newEducation = new Education();
                newEducation.Guid = newGuidd;
                newEducation.Major = createAcc.Major;
                newEducation.Degree = createAcc.Degree;
                newEducation.Gpa = createAcc.Gpa;
                newEducation.UniversityGuid = toUniversity.Guid;

                var cek3 = _educationRepository.Create(newEducation);
                if (cek3 is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status500InternalServerError,
                        Status = HttpStatusCode.InternalServerError.ToString(),
                        Message = "Failed to create Educ",
                    });
                }

                var accountRole = _accountRoleRepository.Create(new AccountRole
                {
                    AccountGuid = newAccount.Guid,
                    RoleGuid = _roleRepository.GetRoleGuid("User") ?? throw new Exception("Default Role Not Found")
                });

                
                transaction.Commit();
                return Ok(new ResponseOKHandler<string>("Account Created"));
            }
            catch (Exception ex)
            {
                // Jika terjadi kesalahan, lakukan rollback transaksi.
                transaction.Rollback();
                // message error jika gagal Insert into DB
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to create Employee",
                    Error = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        // forgot password email
        [HttpPost("forgotPassword")]
        [AllowAnonymous]
        public IActionResult ForgotPassword(ForgotPasswordDto forgotpw)
        {
            var cekEmail = _employeeRepository.GetGuidByEmail(forgotpw.Email);
            if (cekEmail is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email Not Found"
                });
            }

            try
            {
                var entity = _accountRepository.GetByGuid(cekEmail.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                // random objek untuk generate 6 digit
                Random random = new Random();
                int newOtp = random.Next(100000, 999999);

                // update OTP dan ExpiredDate
                Account toUpdate = entity;
                toUpdate.Otp = newOtp;
                toUpdate.IsUsed = false;
                toUpdate.ExpiredDate = DateTime.Now.AddMinutes(5); // add expiredDate 5 menit
                _accountRepository.Update(toUpdate);
                _emailHandler.Send("Forgot Password", $"Your OTP is {toUpdate.Otp}", cekEmail.Email);
                return Ok(new ResponseOKHandler<string>("Code OTP has been send to email"));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal update
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to update data",
                    Error = ex.Message
                });
            }
        }

        // change password account
        [HttpPost("changePassword")]
        [AllowAnonymous]
        public IActionResult ChangePassword(ChangePasswordDto changepw)
        {
            var cekEmail = _employeeRepository.GetGuidByEmail(changepw.Email);
            if (cekEmail is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email Not Found"
                });
            }
            try
            {
                var entity = _accountRepository.GetByGuid(cekEmail.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                Account toReset = entity;
                if (changepw.Password != changepw.Password)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Password tidak sama"
                    });
                }
                if (toReset.Otp != changepw.Otp)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Otp salah"
                    });
                }
                if ((toReset.Otp == changepw.Otp) && (toReset.ExpiredDate < DateTime.Now))
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Otp Expired"
                    });
                }
                if ((toReset.Otp == changepw.Otp) && (toReset.IsUsed == true))
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Otp Telah digunakan"
                    });
                }
                toReset.Password = HashingHandler.HashPassword(changepw.Password);
                toReset.IsUsed = true;
                toReset.ModifiedDate = DateTime.Now;
                _accountRepository.Update(toReset);
                //return Ok(newOtp);
                return Ok(new ResponseOKHandler<string>("Password Has Been Updated"));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal update
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to update data",
                    Error = ex.Message
                });
            }
        }

        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(CreateAccountDto accountDto)
        {
            try
            {
                var cek = _accountRepository.GetByGuid(accountDto.Guid);
                if (cek is not null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status500InternalServerError,
                        Status = HttpStatusCode.InternalServerError.ToString(),
                        Message = "Failed to create data",
                        Error = "Guid sudah ada dalam Database"
                    });
                }
                Account newAccount = accountDto;
                newAccount.Password = HashingHandler.HashPassword(accountDto.Password);
                var result = _accountRepository.Create(newAccount);

                // konversi sesuai yang ada di DTO untuk mengemas data
                return Ok(new ResponseOKHandler<ViewAccountDto>((ViewAccountDto)result));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal Insert into DB
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to create data",
                    Error = ex.Message
                });
            }
        }


        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // konversi sesuai yang ada di DTO untuk mengemas data tanpa password
            var data = result.Select(item => (ViewAccountDto)item);
            //return Ok(data);
            return Ok(new ResponseOKHandler<IEnumerable<ViewAccountDto>>(data));
        }

        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _accountRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // konversi sesuai yang ada di DTO untuk mengemas data tanpa password
            return Ok(new ResponseOKHandler<ViewAccountDto>((ViewAccountDto)result));
        }

        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(AccountDto accountDto)
        {
            try
            {
                var entity = _accountRepository.GetByGuid(accountDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }

                Account toUpdate = accountDto;
                toUpdate.CreatedDate = entity.CreatedDate;
                toUpdate.Password = HashingHandler.HashPassword(accountDto.Password);
                _accountRepository.Update(toUpdate);

                return Ok(new ResponseOKHandler<string>("Data Updated"));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal update
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to update data",
                    Error = ex.Message
                });
            }
        }

        // Delete data sesuai ID dengan metode DELETE
        [HttpDelete]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var result = _accountRepository.GetByGuid(guid);
                if (result is null)
                {
                    //return NotFound("Id Not Found");
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                _accountRepository.Delete(result);
                //return Ok(delete);
                return Ok(new ResponseOKHandler<string>("Data Deleted"));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal delete data
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to create data",
                    Error = ex.Message
                });
            }
        }
    }
}
