// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$.ajax({
//    url: "/employee/GetAllEmployee/"
//}).done((res) => {
//    console.log(res);
//}).fail((err) => {
//    console.log(err);
//})
const token = '@Context.Session.GetString("JWToken")';
console.log(token);

$.ajax({
    url: "account/gettoken"+token,
    dataType: "JSON",
    headers: {
        "Authorization": "Bearer " + token,
    },
}).done((result) => {
    console.log("done");

    console.log(result);
}).fail((error) => {
    console.log("fail");
    console.log(error);
})