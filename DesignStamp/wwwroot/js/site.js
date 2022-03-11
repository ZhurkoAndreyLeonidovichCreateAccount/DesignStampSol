// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var CustomersCount = 0;

$(document).ready(function () {
    // --- Add/Remove -------------------------------------------------
    $("#differ").click(AddHole);
    $(".remove-customer").click(RemoveCustomer);
    // ----------------------------------------------------------------
});

function AddCustomer() {
    //добавляем поля

    var CustomerContainer = $("<div/>").attr("class", "customer-container")
        .attr("id", "CustomerContainer" + CustomersCount).appendTo("#Customers");

    var Wrapper = $("<div/>").attr("class", "wrapper w5 p96 float-md-left").appendTo(CustomerContainer);

    $("<div/>").attr("class", "box1").text("ФИО заказчика: ").appendTo(Wrapper);
    $("<div/>").text("Телефон: ").appendTo(Wrapper);
    var DivForMess = $("<div/>").appendTo(Wrapper);
    $("<img/>").attr("class", "icon").attr("src", "/Images/viber.png").attr("title", "viber").appendTo(DivForMess);
    $("<img/>").attr("class", "icon").attr("src", "/Images/telegram.png").attr("title", "telegram").appendTo(DivForMess);
    $("<img/>").attr("class", "icon").attr("src", "/Images/whatsapp.png").attr("title", "whatsapp").appendTo(DivForMess);
    $("<div/>").text("Email: ").appendTo(Wrapper);
    $("<div/>").text("Другая связь: ").appendTo(Wrapper);
    //$("<div/>").attr("style", "width: 50px").appendTo(Wrapper);
}