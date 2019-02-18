//////////////////////////
//#region MULTISELECT DROP DOWN LIST

$('.dropdown-toggle').click(function () {
    $('.dropdown').attr('closeable', 'true');
});

$('.dropdown').focusout(function () {
    $('.dropdown').attr('closeable', 'true');
});

$('.dropdown-menu').click(function () {
    $('.dropdown').attr('closeable', 'false');
});

$('.dropdown').on('hide.bs.dropdown', function () {
    if ($('.dropdown').attr('closeable') !== 'true') {
        return false;
    }
})

//#endregion MULTISELECT DROP DOWN LIST
//////////////////////////

////////////
//#region IMAGE BROWSE

function readURL(input) {
    var image = input.files[0];
    if (typeof image !== 'undefined') {

        var reader = new FileReader();
        reader.onload = function (e) {
            $(input).closest('div.form-group').find('.category-img').attr('src', e.target.result);
        }

        reader.readAsDataURL(image);
    }
    else {
        $('.file-clear').click();
    }
}

$('.file-trigger').click(function () {
    $(this).closest('div.form-group').find('.file-browse').click();
})

$('.category-img').click(function () {
    $(this).closest('div.form-group').find('.file-browse').click();
})

$('.file-browse').change(function () {
    readURL(this);
})

$('.file-clear').click(function () {
    $(this).closest('div.form-group').find('.category-img').attr('src', '/Resources/Images/no-img.png');
    $('#pictureId').attr('value', null);
})

//#endregion IMAGE BROWSE
////////////