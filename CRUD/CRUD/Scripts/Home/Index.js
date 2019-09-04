$(function () {
    jQuery('#loaderbody').addClass('hide');

    //En el evento 'ajaxStart' removemos la clase 'hide'
    jQuery(document).bind('ajaxStart', function () {
        jQuery('#loaderbody').removeClass('hide');
        //En el evento 'ajaxStop' asignamos la clase 'hide'
    }).bind('ajaxStop', function () {
        jQuery('#loaderbody').addClass('hide');
        });
});