const User = require("../Task02");

describe("addToCart", () => {
  let user;

  beforeEach(() => {
    user = new User("Ahmed", "1234");
  });

  it("should add product to cart", () => {
    const product = { name: "Book", price: 50 };

    user.addToCart(product);

    expect(user.cart.length).toBe(1);
    expect(user.cart).toContain(product);
  });
});

describe("calculateTotalCartPrice", () => {
  let user;

  beforeEach(() => {
    user = new User("Ahmed", "1234");
  });

  it("should return total price of cart", () => {
    user.addToCart({ name: "Book", price: 50 });
    user.addToCart({ name: "Pen", price: 20 });

    expect(user.calculateTotalCartPrice()).toBe(70);
  });

  it("should return 0 if cart is empty", () => {
    expect(user.calculateTotalCartPrice()).toBe(0);
  });
});

describe("checkout", () => {
  let user;

  beforeEach(() => {
    user = new User("Ahmed", "1234");
  });

  it("should call payment methods and return true if verified", () => {
    const paymentModel = {
      goToVerifyPage: jasmine.createSpy("goToVerifyPage"),
      returnBack: jasmine.createSpy("returnBack"),
      isVerify: jasmine.createSpy("isVerify").and.returnValue(true),
    };

    const result = user.checkout(paymentModel);

    expect(paymentModel.goToVerifyPage).toHaveBeenCalled();
    expect(paymentModel.returnBack).toHaveBeenCalled();
    expect(paymentModel.isVerify).toHaveBeenCalled();
    expect(result).toBeTrue();
  });

  it("should return false if payment not verified", () => {
    const paymentModel = {
      goToVerifyPage: jasmine.createSpy("goToVerifyPage"),
      returnBack: jasmine.createSpy("returnBack"),
      isVerify: jasmine.createSpy("isVerify").and.returnValue(false),
    };

    const result = user.checkout(paymentModel);

    expect(result).toBeFalse();
  });
});
