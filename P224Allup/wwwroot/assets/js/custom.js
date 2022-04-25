$(document).ready(function () {
    $(document).on("click", "#productdetail", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => response.text())
            .then(data => {
                $(".modal-content").html(data)

                $('.quick-view-image').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asNavFor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    asNavFor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusOnSelect: true,
                    speed: 400,
                });

                $("#productQuickModal").modal("show")
            })
    })

    $(document).on("click", "#addbasketbtn", function (e) {
        e.preventDefault()

        let url = $("#basketform").attr("action")
        let count = $("#productcount").val();
        url = url + "?count=" + count;
        fetch(url).then(response =>
        {
            return response.json();
        }).then(data => console.log(data))
    })
})