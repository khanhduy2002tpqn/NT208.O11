// Lấy biểu tượng và biểu mẫu đăng nhập bằng ID
const showLoginFormIcon = document.getElementById("showLoginForm");
const loginForm = document.getElementById("loginForm");
if (showLoginFormIcon) {
    showLoginFormIcon.addEventListener("click", function () {
        // Thêm class active vào biểu mẫu đăng nhập
        loginForm.classList.add("active-form");
    });
}
// Bắt sự kiện click vào biểu tượng;

