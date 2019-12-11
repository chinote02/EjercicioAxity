var Enumerables = {
    MetodosHTTP: {
        Get: { value: 1, name: "GET" },
        Post: { value: 2, name: "POST" },
        Put: { value: 3, name: "PUT" },
        Patch: { value: 4, name: "PATCH" },
        Delete: { value: 5, name: "DELETE" }
    }
};

var Ajax = {
    Request:
        function (type, url, dataSend, onSuccess, onError, async, onComplete) {
            async = async === undefined || async === null ? true : async;

            var config = {
                type: type || "GET",
                url: url,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                async: async,
                success: onSuccess,
                error: onError,
                complete: onComplete
            };

            if (dataSend) {
                config.data = dataSend;
            }

            $.ajax(config);
        }
};