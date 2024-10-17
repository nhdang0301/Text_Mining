/*price range*/

 $('#sl2').slider();

	var RGBChange = function() {
	  $('#RGB').css('background', 'rgb('+r.getValue()+','+g.getValue()+','+b.getValue()+')')
	};	
		
/*scroll to top*/

$(document).ready(function(){
	$(function () {
		$.scrollUp({
	        scrollName: 'scrollUp', // Element ID
	        scrollDistance: 300, // Distance from top/bottom before showing element (px)
	        scrollFrom: 'top', // 'top' or 'bottom'
	        scrollSpeed: 300, // Speed back to top (ms)
	        easingType: 'linear', // Scroll to top easing (see http://easings.net/)
	        animation: 'fade', // Fade, slide, none
	        animationSpeed: 200, // Animation in speed (ms)
	        scrollTrigger: false, // Set a custom triggering element. Can be an HTML string or jQuery object
					//scrollTarget: false, // Set a custom target element for scrolling to the top
	        scrollText: '<i class="fa fa-angle-up"></i>', // Text for element, can contain HTML
	        scrollTitle: false, // Set a custom <a> title if required.
	        scrollImg: false, // Set true to use image
	        activeOverlay: false, // Set CSS color to display scrollUp active point, e.g '#00FFFF'
	        zIndex: 2147483647 // Z-Index for the overlay
		});
	});
});

document.addEventListener('DOMContentLoaded', function () {
    function setActiveNavLink() {
        const currentUrl = window.location.href;
        document.querySelectorAll('.navbar-nav a').forEach(function (link) {
            // Xóa class 'active' khỏi tất cả các liên kết
            link.classList.remove('active');
            // Thêm class 'active' nếu href khớp với URL hiện tại
            if (link.href === currentUrl) {
                link.classList.add('active');
            }
        });
    }

    // Gọi hàm khi trang được tải
    setActiveNavLink();

    // Thêm sự kiện 'click' cho các liên kết
    document.querySelectorAll('.navbar-nav a').forEach(function (link) {
        link.addEventListener('click', function (event) {
            event.preventDefault(); // Ngăn chặn hành vi điều hướng mặc định

            // Xóa class 'active' khỏi tất cả các liên kết
            document.querySelectorAll('.navbar-nav a').forEach(function (item) {
                item.classList.remove('active');
            });

            // Thêm class 'active' vào liên kết được nhấp
            this.classList.add('active');

            // Điều hướng đến trang mới
            window.location.href = this.href;
        });
    });
});
// logout
function confirmLogout() {
    Swal.fire({
        title: 'Are you sure?',
        text: "You will be logged out of your account!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#338edd',
        cancelButtonColor: '#fc3503',
        confirmButtonText: 'Yes',
        cancelButtonText: 'No',
        customClass: {
            popup: 'swal-wide'  // Class CSS tùy chỉnh để thay đổi kích thước
        }
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = '/auth/logout'; // Chuyển hướng sau khi người dùng bấm "Yes"
        }
    });
    return false; // Chặn việc chuyển hướng mặc định của link
}
// wishlist
$(document).ready(function () {
    $('.add-to-wishlist').on('click', function () {
        var productId = $(this).data('product-id');

        $.ajax({
            url: '/User/AddToWishlist', // Đường dẫn đến phương thức AddToWishlist
            type: 'POST',
            data: { id: productId },
            success: function (response) {
                var message = $('#wishlist-message');

                if (response.success) {
                    // Hiển thị thông báo thành công
                    message.text(response.message);
                    message.removeClass('error'); // Loại bỏ class 'error' nếu có
                    message.addClass('success'); // Thêm class 'success' nếu thành công
                } else {
                    // Hiển thị thông báo lỗi (ví dụ: chưa đăng nhập hoặc sản phẩm đã có trong wishlist)
                    message.text(response.message);
                    message.removeClass('success'); // Loại bỏ class 'success' nếu có
                    message.addClass('error'); // Thêm class 'error' cho thông báo lỗi
                }

                // Hiển thị thông báo
                message.addClass('show');

                // Ẩn thông báo sau 3 giây
                setTimeout(function () {
                    message.removeClass('show');
                }, 3000);
            },
            error: function (xhr, status, error) {
                alert('Failed to add product to wishlist. Please try again.');
            }
        });
    });
});
// cart
$(document).ready(function () {
    $('.add-to-cart').on('click', function () {
        var productId = $(this).data('product-id');

        $.ajax({
            url: '/User/AddToCart', // Đường dẫn đến phương thức AddToCart
            type: 'POST',
            data: { id: productId },
            success: function (response) {
                var message = $('#cart-message');

                if (response.success) {
                    // Hiển thị thông báo thành công
                    message.text(response.message);
                    message.removeClass('error'); // Loại bỏ class 'error' nếu có
                    message.addClass('success'); // Thêm class 'success' nếu thành công
                } else {
                    // Hiển thị thông báo lỗi (ví dụ: chưa đăng nhập hoặc sản phẩm không tồn tại)
                    message.text(response.message);
                    message.removeClass('success'); // Loại bỏ class 'success' nếu có
                    message.addClass('error'); // Thêm class 'error' cho thông báo lỗi
                }

                // Hiển thị thông báo
                message.addClass('show');

                // Ẩn thông báo sau 3 giây
                setTimeout(function () {
                    message.removeClass('show');
                }, 3000);
            },
            error: function (xhr, status, error) {
                alert('Failed to add product to cart. Please try again.');
            }
        });
    });
});


// Hàm cập nhật tổng giá cho từng sản phẩm
function updateProductTotal(inputElement) {
    const unitPrice = parseFloat(inputElement.getAttribute('data-unit-price'));  // Lấy giá đơn vị
    const quantity = parseInt(inputElement.value);  // Lấy số lượng mới

    // Tính toán tổng giá cho sản phẩm này
    const totalPrice = unitPrice * quantity;

    // Cập nhật tổng giá của sản phẩm trên giao diện
    const productTotalElement = inputElement.closest('tr').querySelector('.product-total');
    productTotalElement.textContent = '€' + totalPrice.toFixed(2);
}

// Hàm gửi AJAX để cập nhật số lượng và lấy tổng giỏ hàng
function updateCartQuantity(productId, quantity) {
    $.ajax({
        url: '/User/UpdateCartQuantity',
        type: 'POST',
        data: {
            id: productId,
            quantity: quantity
        },
        success: function (response) {
            if (response.success) {
                // Cập nhật tổng giỏ hàng từ server
                document.querySelector('.total-price').textContent = 'Total: €' + response.total.toFixed(2);
            } else {
                console.error(response.message);
            }
        },
        error: function () {
            console.error("Error updating cart quantity");
        }
    });
}

// Lắng nghe sự kiện khi số lượng thay đổi
document.querySelectorAll('.quantity-input').forEach(input => {
    input.addEventListener('input', function () {
        const productId = this.getAttribute('data-product-id');  // Lấy ID sản phẩm
        const quantity = parseInt(this.value);  // Lấy số lượng mới

        // Cập nhật tổng giá sản phẩm trên giao diện
        updateProductTotal(this);

        // Gửi AJAX để cập nhật cơ sở dữ liệu và tính lại tổng giỏ hàng
        updateCartQuantity(productId, quantity);
    });
});



