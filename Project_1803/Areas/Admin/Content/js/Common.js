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
