$(document).ready(function() {
    $.validator.addMethod('date', function (value, element) {
        if (this.optional(element)) {
            return true;
        }
        var valid = true;
        try {
            $.datepicker.parseDate('dd/mm/yy', value);
        }
        catch (err) {
            valid = false;
        }
        return valid;
    });
    $(document).on("focus", ".datepicker", function () {
        $(this).datepicker({ dateFormat: 'dd/mm/yy' });
       
        return;

    });

    $(document).on("click", "a[data-post]", function(e) {
        e.preventDefault();
        var btn = $(this);
        var message = $(this).data("post");
        if (!confirm(message))
            return;


        $.post(btn.attr("href"),
            { id: $(this).data("id") },
            function(data) {
                if (data.Success) {

                    btn.closest("tr").remove();
                } else {

                    window.location.reload(true);

                }
            });

    });


    $(".checkboxEditor > li > a").click(function(e) {

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