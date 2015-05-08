$(document).ready(function() {
    $(".template").hide();
    $("#ddlBank").change(function() {


        $("#myTable .newrow").remove();
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/admin/Branches/GetBranches",
            data: { id: $(this).val() },
            success: function(data) {
                $.each(data, function(i, branch) {
                    $(".template").clone().show().
                        removeClass("template").addClass("newrow").
                        find(".name").text(branch.Name).end()
                        .find(".ids").html(branch.Id).end()
                        .find(".createdBy").html(branch.CreatedBy).end()
                        .find(".btn-edit").attr("href", "/admin/Branches/Edit/" + branch.Id).end()
                        .find(".btn-delete")
                        .attr("href", "/admin/Branches/Delete")
                        .attr("data-post", "هل تريد حذف فرع " + branch.Name + "?!!")
                        .attr("data-id", branch.Id)
                        .end()
                        .appendTo($("#myTable"));


                });

            },
            error: function() {
                console.log("error");

            }

        });


    });


});