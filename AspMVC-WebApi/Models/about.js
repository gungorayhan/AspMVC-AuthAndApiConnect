


function deneme() {

    $.ajax({
        type: "POST",
        url: "/About/deneme/",
        data: { title: "asdasd", category: "sfddsfds", description:""},
        success: function (data) {
            alert("deneme verisi geldi");

        }
    })

}