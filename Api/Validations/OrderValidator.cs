using Api.Models;
using FluentValidation;
using Services.Store;

namespace Api.Validations {
    public class OrderValidator : AbstractValidator<OrderModel> {
        private readonly IOrderRepository _orderRepository;

        public OrderValidator(IOrderRepository orderRepository) {
            _orderRepository = orderRepository;

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Vui lòng nhập số điện thoại!")
                .MaximumLength(16)
                .WithMessage("Số điện thoại không được vượt quá 16 chữ số!");

            RuleFor(x => x.Email)
                .MaximumLength(64)
                .WithMessage("Địa chỉ email không được vượt quá 64 ký tự!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Vui lòng nhập tên người nhận!")
                .MaximumLength(64)
                .WithMessage("Tên người nhận không được vượt quá 64 ký tự!");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Vui lòng nhập địa chỉ!")
                .MaximumLength(512)
                .WithMessage("Địa chỉ không được vượt quá 512 ký tự!");

            RuleFor(x => x.AddressDescription)
                .MaximumLength(512)
                .WithMessage("Mô tả không được vượt quá 512 ký tự!");

            RuleFor(x => x.Notes)
                .MaximumLength(1024)
                .WithMessage("Ghi chú không được vượt quá 1024 ký tự!");

            RuleFor(x => x.OrderProducts)
                .NotEmpty()
                .WithMessage("Giỏ hàng của bạn hiện chưa có sản phẩm, vui lòng kiểm tra lại!");
        }
    }
}
