$(document).ready(function () {

    $(function () {
        $("#grid").jqGrid({
            url: "/admin/Employee/GetEmployees",
            datatype: "json",

            colNames: ['Id', 'الأسم', 'القسم', 'الكود', 'الرقم القومى', 'رقم الكارت', 'تعديل', 'حذف'],
            colModel: [
                { Key: true, hidden: true, name: 'Id', index: 'Id' },
                { Key: false, name: 'Name' },
                { Key: false, name: 'DepName' },
                { Key: false, name: 'Code' },
                 { Key: false, name: 'NationalId' },
                  { Key: false, name: 'ATMNum' },
                //{ Key: false, name: 'DOB', formatter: 'date', formatoptions: { newformat: 'd/m/Y' } },
                { name: 'تعديل', search: false, index: 'Id', width: 30, sortable: false, formatter: editLink },
            { name: 'حذف', search: false, index: 'Id', width: 30, sortable: false, formatter: delLink }
            ],
            mtype: "Get",
            loadonce: true,
            pager: jQuery("#pager"),
            rowNum: 10,
            rowList: [10, 20, 30, 40],
            height: '100%',
            viewrecords: true,
            caption: 'الموظفين',
            emptyrecords: 'No data',
            jsonReader: {
                root: 'rows',
                page: 'page',
                total: 'total',
                records: 'records',
                repeatitems: false,
                id: 0

            },
            autowidth: true,
            multiselect: false



        })
            .navGrid('#pager', {search:true,edit:false,add:false,del:false})
            .filterToolbar({ stringResult: true, searchOnEnter: false, defaultSearch: "cn" });;

    });


    function editLink(cellValue, options, rowdata, action) {
        return "<a href='/Admin/Employee/Edit/" + rowdata.Id + "' class='ui-icon ui-icon-pencil' ></a>";

    }


    function delLink(cellValue, options, rowdata, action) {
        return "<a href='/Admin/Employee/Delete/" + rowdata.Id + "' class='ui-icon ui-icon-close'data-post='هل تريد حذف الدرجة حذف نهائى ؟!!' ></a>";

    }



    $("#PositionDate").val($("#SataffPosition_StartDate").val());



    var ddl = function(ctrlName, targetCtrl, url) {
        $(ctrlName).change(function () {
            console.log($(ctrlName).val());
            $.ajax({
                type: "POST",
                dataType: "json",
                url: url,
                data: { id: $(this).val() },
                success: function(data) {
                    console.log(data);
                    var dataitems = "<option>--اختار --</option>";
                    $.each(data, function (i, sub) {
                        console.log(sub);
                        dataitems += "<option value=" + sub.Id + " >" + sub.Name + "</option>";
                    });
                    $(targetCtrl).html(dataitems);
                }


            });


        });
    };




  

    ddl("#SelectedBank", "#ddlbranch", "/admin/Employee/GetBranches");
    ddl("#SelectedPosition", "#ddlposition", "/admin/Employee/GetSubPosition");


    $("#ddlbranch2").change(function () {
        $("#branchId").val($(this.val()));


    });

});