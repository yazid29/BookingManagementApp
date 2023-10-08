using API.Contracts;
using API.DTO.Bookings;
using API.DTO.Employees;
using API.Utilities.Handler;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ITokenHandler _tokenHandler;
        public BookingController(IBookingRepository bookingRepository, 
            ITokenHandler tokenHandler,
            IEmployeeRepository employeeRepository,
            IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _tokenHandler = tokenHandler;
            _employeeRepository = employeeRepository;
            _roomRepository = roomRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateBookingDto bookingDto)
        {
            // Mengambil isi dari request
            HttpContext httpContext = HttpContext;

            // Dapatkan header Authorization dari request untuk ambil email user
            /*
            string authorizationHeader = httpContext.Request.Headers["Authorization"];
            var cekE = _tokenHandler.GetEmailfromToken(authorizationHeader);
            if(cekE == "")
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status401Unauthorized,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Silahkan Login Terlebih Dahulur"
                });
            }
            */
            try
            {
                var result = _bookingRepository.Create(bookingDto);
                // konversi sesuai yang ada di DTO untuk mengemas data
                return Ok(new ResponseOKHandler<BookingDto>((BookingDto)result));
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
        [HttpGet("room-used")]
        [Authorize]
        public IActionResult GetRoom()
        {
            var rooms = _roomRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var bookings = _bookingRepository.GetAll();
            // join table employee dan room pada table booking sesuai Guid
            var roomUsed = from bo in bookings
                           join emp in employees on bo.EmployeeGuid equals emp.Guid
                           join ro in rooms on bo.RoomGuid equals ro.Guid
                           where bo.StartDate.Date == DateTime.Now.Date && bo.EndDate.Date > DateTime.Now.Date
                           select new RoomUsedDto
                           {
                               BookingGuid = bo.Guid,
                               RoomName = ro.Name,
                               Floor = ro.Floor,
                               Capacity = ro.Capacity,
                               BookedBy = string.Concat(emp.FirstName, " ", emp.LastName)
                           };

            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok(new ResponseOKHandler<IEnumerable<RoomUsedDto>>(roomUsed));
        }
        // tampilkan semua data dengan metode GET
        [HttpGet("booking-detail")]
        [Authorize]
        public IActionResult GetDetailBooking()
        {
            var rooms = _roomRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var bookings = _bookingRepository.GetAll();
            // join table employee dan room pada table booking sesuai Guid
            var roomUsed = from bo in bookings
                           join emp in employees on bo.EmployeeGuid equals emp.Guid
                           join ro in rooms on bo.RoomGuid equals ro.Guid
                           select new BookingDetailsDto
                           {
                               Guid = bo.Guid,
                               BookedNIK = emp.Nik,
                               BookedBy = string.Concat(emp.FirstName, " ", emp.LastName),
                               RoomName = ro.Name,
                               StartDate = bo.StartDate,
                               EndDate = bo.EndDate,
                               Status = bo.Status,
                               Remarks = bo.Remarks
                           };

            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok(new ResponseOKHandler<IEnumerable<BookingDetailsDto>>(roomUsed));
        }
        // tampilkan detail data sesuai Guid booking
        [HttpGet("booking-detail/{guid}")]
        [Authorize]
        public IActionResult GetDetailBookingGuid(Guid guid)
        {
            var rooms = _roomRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var bookings = _bookingRepository.GetAll();
            // join table employee dan room pada table booking sesuai Guid
            var roomUsed = from bo in bookings
                           join emp in employees on bo.EmployeeGuid equals emp.Guid
                           join ro in rooms on bo.RoomGuid equals ro.Guid
                           where bo.Guid == guid
                           select new BookingDetailsDto
                           {
                               Guid = bo.Guid,
                               BookedNIK = emp.Nik,
                               BookedBy = string.Concat(emp.FirstName, " ", emp.LastName),
                               RoomName = ro.Name,
                               StartDate = bo.StartDate,
                               EndDate = bo.EndDate,
                               Status = bo.Status,
                               Remarks = bo.Remarks
                           };
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok(new ResponseOKHandler<IEnumerable<BookingDetailsDto>>(roomUsed));
        }
        // tampilkan detail data sesuai Guid booking
        [HttpGet("booking-length/{guid}")]
        [Authorize]
        public IActionResult GetLengthBooking(Guid guid)
        {
            var rooms = _roomRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var bookings = _bookingRepository.GetAll();
            // join table employee dan room pada table booking sesuai Guid
            var bookingData = from bo in bookings
                           join emp in employees on bo.EmployeeGuid equals emp.Guid
                           join ro in rooms on bo.RoomGuid equals ro.Guid
                           where bo.Guid == guid
                           select new
                           {
                               Guid = bo.Guid,
                               BookedNIK = emp.Nik,
                               BookedBy = string.Concat(emp.FirstName, " ", emp.LastName),
                               RoomGuid = ro.Guid,
                               RoomName = ro.Name,
                               StartDate = bo.StartDate,
                               EndDate = bo.EndDate,
                               Status = bo.Status,
                               Remarks = bo.Remarks
                           };
            // declarasi variable untuk menampung durasi
            int durationCek = 0;
            int realDuration = 0;
            var cek = bookingData.FirstOrDefault();
            
            if(cek is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // jika ada data maka hitung endDate-startDate untuk total durasi booking
            // kemudian ketika hari sabtu dan minggu tidak dihitungkan dalam durasi booking
            // dapat menggunakan perulangan sebagai berikut
            else {
                var bookingDuration = cek.EndDate - cek.StartDate;
                durationCek = Convert.ToInt32(bookingDuration.TotalDays);
                // dari total durasi akan dicek harinya dapat dicek
                // dengan salah satu method DateTime.DayofWeek untuk mengambil hari
                
                for (int i=0;i< durationCek; i++)
                {
                    // tambahkan tanggal mulai sampai berakhir,
                    // penambahan tanggal dimulai dari 0 hingga durasiTotal
                    DateTime currentDate = cek.StartDate.AddDays(i);
                    if(currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday) {
                        // ketika tanggal tersebut bukan hari sabtu/minggu maka durasi akan ditambah
                        realDuration++;
                    }
                }
            }
            BookingLengthDto lengthBooking = new BookingLengthDto
            {
                RoomGuid = cek.RoomGuid,
                RoomName = cek.RoomName,
                BookingLength = realDuration
            };
            // kirim durasi tanpa hari minggu/sabtu
            return Ok(new ResponseOKHandler<BookingLengthDto>(lengthBooking));
        }
        // tampilkan detail data room yang tidak digunakan pada hari ini
        [HttpGet("room-not-used")]
        [Authorize]
        public IActionResult GetRoomNotUsed(Guid guid)
        {
            var rooms = _roomRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var bookings = _bookingRepository.GetAll();
            // join table employee dan room pada table booking sesuai Guid
            var roomUsed = from bo in bookings
                           join emp in employees on bo.EmployeeGuid equals emp.Guid
                           join ro in rooms on bo.RoomGuid equals ro.Guid
                           where bo.StartDate.Date != DateTime.Now.Date && bo.EndDate.Date > DateTime.Now.Date
                           select new RoomNotUsedDto
                           {
                               RoomGuid = ro.Guid,
                               RoomName = ro.Name,
                               Floor = ro.Floor,
                               Capacity = ro.Capacity
                           };

            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok(new ResponseOKHandler<IEnumerable<RoomNotUsedDto>>(roomUsed));
        }

        // tampilkan semua data dengan metode GET
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            
            var result = _bookingRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            var data = result.Select(item => (BookingDto) item);
            return Ok(new ResponseOKHandler<IEnumerable<BookingDto>>(data));
        }
        
        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _bookingRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok(new ResponseOKHandler<BookingDto>((BookingDto)result));
        }
        
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(BookingDto bookingDto)
        {
            try
            {
                var entity = _bookingRepository.GetByGuid(bookingDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }

                Booking toUpdate = bookingDto;
                toUpdate.CreatedDate = entity.CreatedDate;
                //return Ok(new ResponseOKHandler<Booking>(toUpdate));
                var cek = _bookingRepository.Update(toUpdate);
                if(cek==false)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status500InternalServerError,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Update"
                    });
                }
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
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var result = _bookingRepository.GetByGuid(guid);
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
                _bookingRepository.Delete(result);
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
