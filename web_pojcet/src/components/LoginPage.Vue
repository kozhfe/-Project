<template>
    <div class="ALL_all">
        <div class="all">
            <div class="all_hid">
                <!-- 登录 -->
                <div class="login">
                    <!-- 登录字样 -->
                    <div class="login_text">登录</div>
                    <!-- 用户名 -->
                    <div class="login_name logcomm">
                        <span class="hint">用户名</span>
                        <input type="text" id="log_name" value="admin" name="User_Name" class="input" placeholder="请输入用户名"><br>
                        <span class="text" id="log_span"></span>
                    </div>
                    <!-- 密码 -->
                    <div class="login_password logcomm">
                        <span class="hint">密码</span>
                        <input class="input" id="Log_pas" value="123456789" name="User_Password" type="password" maxlength="26" placeholder="请输入密码"><br>
                        <span class="text"></span>
                    </div>
                    <!-- 验证码 -->
                    <div class="login_code logcomm">    
                        <span class="hint">验证码</span>
                        <input class="input" id = "inp_code" placeholder="请输验证码" type="text">
                        <div><img src="" id="code_img" /></div>
                    </div>
                    <span class="yzn_text"></span>
                    <!-- 头像 -->
                    <div class="login_photo">
                        <img id="photo_img" src="/img/2022032909323832381446723374.png" alt="">
                    </div>
                    <!-- 登录按钮 -->
                    <div class="login_button logcomm">
                        <input class="but"  id="login_but" type="submit" value="登录">
                        <a class="login_a" href="#">去注册</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<style>
* {
    margin: 0px;
    padding: 0px;
    /* 取消双击变蓝 */
    user-select: none;
}

a {
    text-decoration: none;
}

body {
    /* 清除浮动 */
    clear: both;
    background-color: rgb(247, 243, 243);
    max-width: 1000px;
}
/* 内容范围 */
.ALL_all {
    width: 1535px;
    height: 760px;
}
/* 整体 */
.all {
    width: 600px;
    height: 400px;
    border-radius: 50px;
    /* 相对定位 */
    position: relative;
    left: 500px;
    top: 150px;
    background-color: white;
    /* 阴影 */
    box-shadow: -20px 30px 50px gray;
    /* all:过度属性    600ms：持续时间  
    linear：匀速       10ms：延迟时间 */
    transition: all 300ms linear 10ms;
}

    .all:hover {
        transform: translate(-10px,10px);
        box-shadow: -18px 28px 30px rgb(95, 94, 94);
    }

/* 显示的内容 */
.all_hid {
    overflow: hidden;
    width: 555px;
    height: 360px;
    /* 绝对定位 */
    position: absolute;
    left: 18px;
    top: 18px;
}
/* 公共样式 */
.logcomm {
    width: 330px;
    height: 40px;
    margin-top: 25px;
    margin-left: 230px;
}

.text {
    font-size: 13px;
    color: red;
    margin-left: 90px;
}

.yzn_text {
    display: block;
    font-size: 13px;
    color: red;
    position: absolute;
    left: 323px;
    top: 250px;
}
/* 小眼睛 */
.im {
    width: 15px;
    height: 10px;
}
/* 提示字样 */
.hint {
    letter-spacing: 5px;
    font-weight: 600;
}
/* 输入框样式 */
.input {
    width: 150px;
    height: 25px;
    font-size: 12px;
    margin-left: 10px;
    border-radius: 10px;
    border: solid 1px black;
    /* 取消选中自带的框 */
    outline: none;
    padding: 0px 8px;
    background-color: rgb(241, 241, 241);
}

    .input:focus {
        background-color: white;
    }
/* 按钮样式 */
.but {
    width: 110px;
    height: 28px;
    font-size: 15px;
    font-weight: 600;
    letter-spacing: 18px;
    padding-left: 15px;
    background-color: rgb(58, 228, 240);
    border: none;
    border-radius: 8px;
    /* 取消只带选中框 */
    outline: none;
    /* all:过度属性    600ms：持续时间  
    linear：匀速       10ms：延迟时间 */
    transition: all 300ms linear 5ms;
}
    /* 点击太 */
    .but:active {
        transform: scale(0.1);
    }

    .but:hover {
        background-color: rgb(238, 140, 49);
    }

.login_button {
    width: 200px;
}

/* 登录 */
.login {
    width: 560px;
    height: 360px;
    position: absolute;
    left: 0px;
    float: left;
    /* all:过度属性    600ms：持续时间  
    linear：匀速       10ms：延迟时间 */
    transition: all 300ms linear 50ms;
}
/* 用户名 */
.login_name {
    margin-top: 90px;
}
/* 密码 */
.login_password > span:nth-of-type(1) {
    letter-spacing: 25px;
}

.login_password > input {
    margin-left: -10px;
}
/* 验证码 */
.login_code > input:nth-of-type(1) {
    width: 70px;
}

.login_code > div:nth-of-type(1) {
    width: 70px;
    height: 30px;
    cursor: pointer;
    position: absolute;
    left: 400px;
    top: 210px;
    letter-spacing: 4px;
    text-align: center;
    padding-top: 4px;
}

.login_code > span:nth-of-type(2) {
    position: absolute;
    left: 480px;
    top: 224px;
}
/* 登录按钮模块 */
.login_button {
    height: 50px;
    margin-left: 290px;
}

    .login_button a {
        font-size: 13px;
        margin-left: 10px;
    }

.login_checkbox {
    margin-top: 10px;
    margin-left: 10px;
    width: 150px;
    height: 20px;
}

    .login_checkbox input {
        width: 15px;
        height: 15px;
    }

    .login_checkbox a {
        position: absolute;
        top: 324px;
    }
/* 头像 */
.login_photo {
    width: 200px;
    height: 200px;
    position: absolute;
    top: 80px;
}

    .login_photo img {
        width: 180px;
        height: 180px;
        border-radius: 50%;
        position: relative;
        left: 10px;
        top: 10px;
        /* all:过度属性    600ms：持续时间  
    linear：匀速       10ms：延迟时间 */
        transition: all 300ms linear 10ms;
    }
/* 旋转帧 */
@keyframes img {
    font {
        transform: rotate(0);
    }

    to {
        transform: rotate(2turn);
    }
}

.login_photo img:hover {
    /* animation:关键帧组名  持续时间 
     动画速度  延迟时间  播放次数 */
    animation: img 10000ms linear 100ms infinite;
    width: 190px;
    height: 190px;
    position: relative;
    left: 5px;
    top: 5px;
}

/* 登录字样 */
.login_text {
    width: 120px;
    height: 40px;
    text-align: center;
    font-weight: 600;
    font-size: 30px;
    /* 间隔 */
    letter-spacing: 30px;
    position: absolute;
    left: 230px;
}
/* 查看密码 */
.log {
    position: absolute;
    top: 164px;
    left: 450px;
}




/* 注册 */
.register {
    width: 560px;
    height: 360px;
    position: absolute;
    left: 560px;
    float: left;
    /* all:过度属性    600ms：持续时间  
    linear：匀速       10ms：延迟时间 */
    transition: all 300ms linear 10ms;
}
/* 输入框样式 */
.register_input {
    width: 120px;
    height: 25px;
    font-size: 12px;
    margin-left: 10px;
    border-radius: 10px;
    border: solid 1px black;
    /* 取消选中自带的框 */
    outline: none;
    padding: 0px 8px;
    background-color: rgb(241, 241, 241);
}

    .register_input:focus {
        background-color: white;
    }
/* 注册字样样式 */
.register_text {
    width: 120px;
    height: 40px;
    text-align: center;
    font-weight: 600;
    font-size: 30px;
    /* 间隔 */
    letter-spacing: 30px;
    position: absolute;
    left: 230px;
}
/* div样式 */
.re {
    width: 280px;
    height: 40px;
    margin-top: 20px;
}

.re_register {
    width: 280px;
    height: 40px;
    margin-top: 20px;
}

.reg_text {
    font-size: 13px;
    color: red;
    position: relative;
    left: 90px;
}

.reg_text_left {
    font-size: 13px;
    color: red;
    position: relative;
    left: 110px;
}
/* 左 */
.register_left {
    width: 270px;
    height: 280px;
    margin-top: 40px;
    float: left;
    margin-left: 5px;
}
/* 右 */
.register_right {
    width: 270px;
    height: 280px;
    margin-top: 40px;
    margin-left: 15px;
    float: left;
}
/* 用户名 */
.register_name {
    margin-top: 20px;
}

    .register_name > span:nth-of-type(1) {
        letter-spacing: 13px;
    }
/* 姓名 */
.register_User {
    margin-top: 20px;
}

    .register_User > span:nth-of-type(1) {
        letter-spacing: 15px;
    }
/* 密码 */
.register_password > span:nth-of-type(1) {
    letter-spacing: 26px;
}
/* 性别 */
.register_cell > span:nth-of-type(1) {
    letter-spacing: 26px;
    margin-left: 1px;
}

.register_cell span {
    margin-left: 10px;
}

.register_cell input {
    margin-left: 5px;
}
/* 邮箱 */
.register_mailbox > span:nth-of-type(1) {
    letter-spacing: 26px;
}
/* 头像 */
.register_photo > span:nth-of-type(1) {
    letter-spacing: 26px;
}

.register_photo > input:nth-of-type(1) {
    width: 150px;
    border-radius: 8px;
    margin-left: -10px;
    background-color: gray;
}
/* 注册按钮 */
.register_button {
    width: 240px;
    height: 60px;
    position: absolute;
    top: 305px;
    left: 240px;
}
/* 按钮样式 */
.reg {
    width: 110px;
    height: 28px;
    font-size: 15px;
    font-weight: 600;
    letter-spacing: 18px;
    padding-left: 15px;
    background-color: rgb(58, 228, 240);
    border: none;
    border-radius: 8px;
    /* 取消只带选中框 */
    outline: none;
    /* all:过度属性    600ms：持续时间  
    linear：匀速       10ms：延迟时间 */
    transition: all 300ms linear 5ms;
}

    .reg:active {
        transform: scale(0.1);
    }

    .reg:hover {
        background-color: rgb(238, 140, 49);
    }

.register_button a {
    font-size: 13px;
    margin-left: 10px;
}

.reg_checkbox {
    width: 140px;
    height: 30px;
    margin-top: 5px;
    margin-left: 13px;
}

    .reg_checkbox > a {
        position: relative;
        top: -1px;
        left: -4px;
    }
/* 小眼睛 */
.reg_in {
    position: absolute;
    top: 129px;
    left: 217px;
}

.reg_ing {
    position: absolute;
    top: 189px;
    left: 217px;
}

</style>