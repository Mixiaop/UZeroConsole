var vc = {};
vc.options = {
    refreshTime: parseInt($('.js-refresh-time').val()) * 1000
};
if (isNaN(vc.options.refreshTime)) {
    vc.options.refreshTime = 0;
}

vc.modules = {};

vc.modules.refresh = function () {
    var _refreshData = function () {
        
        if (vc.options.refreshTime > 0) {
            $.ajax(window.location.href, {
                cache: false
            }).done(function (html) {
                var $res = $(html);
                $('.js-refresh[data-name]').html($res.find('.js-refresh[data-name]').html());
                if (vc.options.refreshTime > 0) {
                    setTimeout(_refreshData, vc.options.refreshTime);
                }
            })
                .fail(function () {
                    console.log('Failed to refresh', this, arguments);
                });
        }

    }

    return {
        init: function () { _refreshData(); }
    }
}();


vc.modules.refresh.init();