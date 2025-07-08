// 站点通用JavaScript代码

// 确认删除
function confirmDelete(message) {
    return confirm(message || '确定要删除这条记录吗？');
}

// 显示成功消息
function showSuccess(message) {
    if (typeof layui !== 'undefined') {
        layui.use(['layer'], function(){
            var layer = layui.layer;
            layer.msg(message, {icon: 1});
        });
    } else {
        alert(message);
    }
}

// 显示错误消息
function showError(message) {
    if (typeof layui !== 'undefined') {
        layui.use(['layer'], function(){
            var layer = layui.layer;
            layer.msg(message, {icon: 2});
        });
    } else {
        alert(message);
    }
}

// 显示警告消息
function showWarning(message) {
    if (typeof layui !== 'undefined') {
        layui.use(['layer'], function(){
            var layer = layui.layer;
            layer.msg(message, {icon: 0});
        });
    } else {
        alert(message);
    }
}

// 格式化日期
function formatDate(date) {
    if (!date) return '';
    var d = new Date(date);
    var year = d.getFullYear();
    var month = ('0' + (d.getMonth() + 1)).slice(-2);
    var day = ('0' + d.getDate()).slice(-2);
    return year + '-' + month + '-' + day;
}

// 初始化表格
function initTable() {
    if (typeof layui !== 'undefined') {
        layui.use(['table'], function(){
            var table = layui.table;
            // 表格配置可以在这里添加
        });
    }
}