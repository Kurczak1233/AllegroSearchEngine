import { render, screen } from "@testing-library/react";
import Product from "./Product";
import PlaceholderImage from "../../icons/PlaceholderImage.svg";

const product = {
  category: "category",
  id: "id",
  images: null,
  name: "name",
  parameters: [],
};

test("should display placeholder image if there is no image url", () => {
  render(<Product product={product} />);
  const image = screen.getByRole("img");
  expect(image).toHaveAttribute("src", PlaceholderImage);
});

test("should display product name and category", () => {
  render(<Product product={product} />);
  const productWrapperElement = screen.getByRole("product-wrapper");
  expect(productWrapperElement).toHaveTextContent(product.name);
  expect(productWrapperElement).toHaveTextContent(product.category);
});
