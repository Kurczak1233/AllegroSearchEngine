import "./HomePage.scss";
import Logo from "../../icons/Logo.svg";
import HomePageLogic from "./HomePageLogic";
import Product from "../../components/Product/Product";
import React from "react";
const HomePage = () => {
  const { apiCallResult, setPhrase, handleSearchClick, isLoading } =
    HomePageLogic();
  return (
    <>
      <header className="home-page__header">
        <img src={Logo} className={"home-page__logo"} />
        <input
          type={"text"}
          placeholder={"Search for products..."}
          className={"home-page__search-input"}
          onChange={(e) => setPhrase(e.target.value)}
        />
        <div onClick={handleSearchClick} className="home-page__find-button">
          Search
        </div>
      </header>
      <main className="home-page__main">
        <div className="home-page__main-content" role="main-content">
          {isLoading ? (
            <div>Loading...</div>
          ) : (
            <React.Fragment>
              {apiCallResult.map((product) => (
                <Product key={product.id} product={product} />
              ))}
            </React.Fragment>
          )}
        </div>
      </main>
    </>
  );
};

export default HomePage;
