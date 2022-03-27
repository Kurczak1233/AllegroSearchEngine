import React from "react";
import { ProductViewModel } from "../../models/ProductViewModel";
import "./Product.scss";
import PlaceholderImage from "../../icons/PlaceholderImage.svg";

interface IProduct {
  product: ProductViewModel;
}

const Product = ({ product }: IProduct) => {
  return (
    <div className="product__wrapper" role="product-wrapper">
      <img
        src={product.images ? product.images : PlaceholderImage}
        className="product__image"
      />
      <div className="product__description">
        <div>{product.name}</div>
        <div>Category: {product.category}</div>
        {product.parameters.map((parameter) => (
          <div key={parameter.id}>
            {parameter.name}:&nbsp;{parameter.valuesLabels[0]}
          </div>
        ))}
      </div>
    </div>
  );
};

export default Product;
