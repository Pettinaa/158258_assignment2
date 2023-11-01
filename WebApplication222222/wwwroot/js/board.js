// 获取提交按钮和成功消息的元素
var submitButton = document.getElementById("submit");
var successMessage = document.getElementById("successMessage");

// 当提交按钮被点击时
submitButton.addEventListener("click", function() {
    // 显示成功消息
    successMessage.style.display = "block";
    successMessage.textContent = "We've received your message";
    successMessage.style.cssText = "color: white; font-size: 10px; font-family: 'Maven Pro', Tahoma, sans-serif; font-weight: bold;";

    // 清空输入框内容
    var messageInput = document.getElementById("message");
    messageInput.value = "";

    // 2秒后隐藏成功消息
    setTimeout(function() {
        successMessage.style.display = "none";
    }, 2000);
});
