import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import HomePage from "./HomePage";

test("input should be initially empty", () => {
  render(<HomePage />);
  const searchInputElement = screen.getByRole("textbox");
  expect(searchInputElement.value).toBe("");
});

test("input should contain inputted value", () => {
  render(<HomePage />);
  const searchInputElement = screen.getByRole("textbox");
  userEvent.type(searchInputElement, "Laptop");
  expect(searchInputElement.value).toBe("Laptop");
});

test("should call onClick prop when search button clicked", () => {
  const onClick = jest.fn();
  render(<HomePage handleSearchClick={onClick()} />);
  const searchButtonElement = screen.getByText(/Search/);
  userEvent.click(searchButtonElement);
  expect(onClick).toHaveBeenCalledTimes(1);
});

test("should display 'Loading...' when loading data", () => {
  const onClick = jest.fn();
  render(<HomePage handleSearchClick={onClick()} />);
  const searchInputElement = screen.getByRole("textbox");
  const searchButtonElement = screen.getByText(/Search/);
  userEvent.type(searchInputElement, "Laptop");
  userEvent.click(searchButtonElement);
  const mainContentElement = screen.getByRole("main-content");
  expect(mainContentElement).toHaveTextContent(/Loading.../);
});
