
# Current notes

- ***TRƯỚC KHI CHẠY PHẢI VÀO BUILD -> REBUILD SOLUTION ĐỂ BUILD CÁC USERCONTROL***
- Dùng tên đăng nhập `admin` và mật khẩu `admin` để vào chế độ quản lý.
- Khi ở chế độ quản lý có thể thêm nhân viên và tài khoản nhân viên.
- Máy phải cài đặt SQLExpress **2019**.  
- File .mdf của database chứa trong `|DataDirectory|\database\`
- File poster chứa trong `|DataDirectory|\posters`
- File ảnh sản phẩm chứa trong `|DataDirectory|\product_images`
- Nếu có báo lỗi file mdf đang bị process khác chiếm thì đó là tiến trình Designer của Visual Studio, thoát chương trình vào lại sẽ build được