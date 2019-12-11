var Authenticate = function () {
    var url = '/Home/Login?usr=' + $('#username').val() + '&pwd=' + $('#password').val(); 
	var Response = function (r) {
        if(r.result.HasError){
            $('#login-message').val(r.result.Message);
        } else {
            window.location.href = r.result.HttpReDirect;
        }
    };

    Ajax.Request(Enumerables.MetodosHTTP.Get.name, url, null, Response, null, false, null);
};

$(function() {
    $('#login-submit').click(function(e) { Authenticate(); });
});