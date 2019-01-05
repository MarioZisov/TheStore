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