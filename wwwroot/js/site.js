
document.getElementById('backButton').addEventListener('click', function (event) {
    event.preventDefault(); // Ngăn chặn hành vi mặc định của thẻ <a>
    window.history.back();  // Quay lại trang trước đó
});


//Dieu chinh so luong san pham trong gio hang
        $(document).ready(function () {
            $('.cart-item__quantity-btn').click(function () {
                var spId = $(this).data('id');
                var action = $(this).data('action');
                var url = '';

                if (action === 'increase') {
                    url = '/Cart/AddItemToCart';
                } else if (action === 'decrease') {
                    url = '/Cart/DecreaseItemFromCart';
                }

                $.ajax({
                    url: url,
                    type: 'POST',
                    data: { spId: spId },
                    success: function (response) {
                        if (response.success) {
                            // Cập nhật số lượng trên giao diện
                            if (action === 'increase') {
                                var qty = parseInt($('#qty-' + spId).text()) ;
                                $('#qty-' + spId).text(qty);
                                location.reload();
                            } else if (action === 'decrease') {
                                var qty = parseInt($('#qty-' + spId).text()) ;
                                location.reload();
                                if (qty > 0) {
                                    $('#qty-' + spId).text(qty);
                                } else {
                                    // Reload nếu số lượng về 0 để xóa dòng
                                    location.reload();
                                }
                            }
                        } else {
                            alert(response.message || "Có lỗi xảy ra.");
                        }
                    },
                    error: function () {
                        alert("Có lỗi xảy ra khi cập nhật số lượng.");
                    }
                });
            });
        });
    

        //Dau x xoa san pham
            $(document).ready(function () {
                $('.cart-item__remove').off('click').on('click', function () {
                    var spId = $(this).data('spid');
                    var $itemRow = $(this).closest('.cart-item');
                    $.ajax({
                        url: '/Cart/RemoveItemFromCart',
                        type: 'POST',
                        data: { spId: spId },
                        success: function (response) {
                            if (response.success) {
                                $itemRow.remove();
                                alert(response.message);
                                // Xóa phần tử sản phẩm khỏi giao diện
                                location.reload();
                            } else {
                                alert(response.message || "Có lỗi xảy ra.");
                            }
                        }

                    });
                });
            });



 

        

