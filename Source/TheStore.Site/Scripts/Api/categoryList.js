$(document).ready(function () {
    $('#data-table').DataTable(
        {
            ajax: {
                url: "/api/category",
                dataSrc: ''
            },
            rowId: 'Id',
            columns: [
                {
                    data: 'Name',
                    render: function (colData, dataType, row) {
                        return '<a href="/admin/category/edit/' + row.Id + '">' + colData + '</a>'
                    }
                },
                { data: 'CreatedOn' },
                { data: 'UpdatedOn' },
                { data: 'IsPrimary' },
                { data: 'IsVisible' },
                { data: 'DisplayOrder' },
                {
                    render: function (colData, dataType, row) {
                        //return '<a class="btn btn-danger btn-sm delete" id="' + row.Id + '">Изтрий</а>'
                        return '<a class="btn btn-danger btn-sm delete" data-toggle="modal" data-target="#exampleModal" id="' + row.Id + '">Изтрий</а>'
                    }
                }
            ]
        })

    $('#exampleModal').on('show.bs.modal', function (e) {
        var categoryId = e.relatedTarget.id;
        //var deleteUrl = '/api/category/' + categoryId;
        var deleteButton = $('#exampleModal #modal_delete');

        var categoryNameElement = '#data-table tr#' + categoryId + ' a';
        var modal_label = $(categoryNameElement).html();
        $('#modal_label').html(modal_label);

        deleteButton.on('click', function ()
        {
            $.ajax({
                url: '/api/category/' + categoryId,
                method: 'DELETE'
            })
        })
    })
});

//$(document).ready(function () {
//    $('a.delete').on('click', function () {
//        //$('#exampleModal a.delete').attr('href', '/api/delete/' + $(this).attr('id'))
//        //$('#exampleModal').modal()
//        var x = 0;
//    });
//})