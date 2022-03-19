import React from "react";
import { ProductViewModel } from "../../models/ProductViewModel";
import "./Product.scss";
import PlaceholderImage from "../../icons/PlaceholderImage.svg";

interface IProduct {
  product: ProductViewModel;
}

const Product = ({ product }: IProduct) => {
  return (
    <div className="product__wrapper">
      <img
        src={product.images ? product.images : PlaceholderImage}
        className="product__image"
      />
      <div className="product__description">
        <div>{product.name}</div>
        <div>Category: {product.category}</div>
        <div>
          Description:&nbsp; <br />
          {product.parameters.map((item) => (
            <React.Fragment key={item.id}>
              <span>
                {/* {item.name}:&nbsp;{item.unit}
                {item.values[0]} */}
              </span>
              <br />
            </React.Fragment>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Product;