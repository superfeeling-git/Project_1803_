function ShowMsg(msg, obj) {
    var setting = {
        type: 'success', // 定义颜色主题
        close: false,
        time: 6000
    };

    $.extend(setting, obj);

    new $.zui.Messager(setting).show(msg);
}

//批量操作
function BatchOperator(setting) {

    var config = {
        confirmMsg: "确认删除吗？",
        successMsg: "删除成功",
        type: "get",
        data: {},
        callback: function () { }
    };

    $.extend(config, setting);

    new $.zui.Messager(config.confirmMsg, {
        type: 'success',
        time: 0,
        actions: [{
            name: 'undo',
            icon: 'undo'
        }, {
            name: 'close',
            icon: 'remove'
        }],
        onAction: function (name, action, messager) {
            if (name === 'undo') {
                console.log('你点击了撤销按钮。');
            } else if (name === 'close') {
                //执行删除
                $.ajax({
                    url: config.url,
                    type: config.type,
                    dataType: "json",
                    data: config.data,
                    success: function (d) {
                        config.callback(config.successMsg);
                    }
                })
            }
        }
    }).show();
}

var uploaderSetting = {
    autoUpload: false,            // 当选择文件后立即自动进行上传操作
    url: '/Admin/UploadFile/Index',  // 文件上传提交地址
    limitFilesCount: 1,
    multipart_params: {},
    //browse_button:"#uploaderBtn",
    filters: {
        // 只允许上传图片或图标（.ico）
        mime_types: [
            { title: '图片', extensions: 'jpg,gif,png' },
            { title: '图标', extensions: 'ico' }
        ],
        // 最大上传文件为 1MB
        max_file_size: '1mb',
        // 不允许上传重复文件
        prevent_duplicates: true
    },
    onFileUploaded: function (file, responseObject) {
        var jsonObj = JSON.parse(responseObject.response);

        $("#ItemImg").val(jsonObj.url);

        console.log(jsonObj.url);
        console.log(file);
    }
};