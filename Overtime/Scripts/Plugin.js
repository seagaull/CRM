$(document).ready(function () {
    
    $(".btn-group").on("click", "a[data-post]", function (e) {
        e.preventDefault();
        var btn = $(this);
        var message = $(this).data("post");
        if (!confirm(message))
            return;   
        $("<form>")
            .attr("method", "post")
            .attr("action", btn.attr("href"))
            .appendTo(document.body)
            .submit();
    });



    $(".checkboxEditor >li > a").click(function (e) {

        e.preventDefault();


        var checkboxitem = $(this).closest("li");
        checkboxitem.toggleClass("selected");

        var selecteditems = checkboxitem.hasClass("selected");
        checkboxitem.find(".selected-input").val(selecteditems);


    });

    ($(".selected-input").each(function() {
        if ($(this).val() === "True") {
            $(this).closest("li").addClass("selected");
        }

    }));



});