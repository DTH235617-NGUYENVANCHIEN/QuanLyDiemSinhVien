using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVien.BLL
{
    public class MenuHighlightManager
    {
        private List<Button> allMenuButtons;

        // Màu KÍCH HOẠT (Giữ nguyên)
        private Color activeColor = Color.FromArgb(0, 122, 204); // Màu xanh dương đậm
        private Color activeFontColor = Color.White;

        // THAY ĐỔI Ở ĐÂY:
        // Chúng ta sẽ lưu màu gốc của nút
        private Color originalBackColor;
        private Color originalForeColor;

        // 3. Sửa HÀM KHỞI TẠO (Constructor)
        public MenuHighlightManager(List<Button> menuButtons)
        {
            this.allMenuButtons = menuButtons;

            // THÊM VÀO:
            // "Học" màu gốc từ nút đầu tiên trong danh sách
            if (menuButtons.Count > 0)
            {
                this.originalBackColor = menuButtons[0].BackColor;
                this.originalForeColor = menuButtons[0].ForeColor;
            }
        }

        // 4. Hàm Kích hoạt một nút (Giữ nguyên)
        public void ActivateButton(Button clickedButton)
        {
            ResetAllButtons(); // Đặt lại màu tất cả

            // Kích hoạt nút được chọn
            clickedButton.BackColor = activeColor;
            clickedButton.ForeColor = activeFontColor;
        }

        // 5. Sửa Hàm ĐẶT LẠI TẤT CẢ
        public void ResetAllButtons()
        {
            foreach (Button btn in allMenuButtons)
            {
                // THAY ĐỔI:
                // Thay vì "Transparent", ta dùng màu gốc đã lưu
                btn.BackColor = this.originalBackColor;
                btn.ForeColor = this.originalForeColor;
            }
        }
    }
}
