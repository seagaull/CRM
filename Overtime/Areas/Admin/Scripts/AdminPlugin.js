$(document).ready(function () {

    $.getJSON("/admin/Branches/GetBanks", function (data) {
        var items = "<option>أختار البنك</option>";
        $.each(data, function (i, bank) {
            console.log(bank);
            items += "<option value='" + bank.Value + "'>"
                + bank.Text + "</option>";

        });

        $("#ddlBanks").html(items);
    });

    var temp = $(".template").hide().clone();;
    $("#ddlBanks").change( function () {
        $.getJSON("/admin/Branches/Branches/" + $("#ddlBanks >option:selected").attr("value"),
            function (data) {
                $("#datatable> .cloned").remove();
                $.each(data, function (i, branch) {

                    var items = (temp.removeClass("template")
                        .find(".ids").text(branch.Id).end()
                        .find(".name").text(branch.Name).end()                       
                        .find(".address").text(branch.Address).end()
                        .find(".EditTemp").attr("href", "/admin/Branches/Form/" + branch.Id).end()
                        .find(".DeleteTemp").attr("href", "/admin/Branches/Delete/" + branch.Id).end()
                        
                        .html());

                    $("#datatable").append("<tr class='cloned'>" + items + "</tr>");

                });




            });



    });




        


});