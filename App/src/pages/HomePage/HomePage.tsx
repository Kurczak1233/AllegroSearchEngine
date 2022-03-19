import "./HomePage.scss";
import Logo from "../../public/Logo.svg";
import HomePageLogic from "./HomePageLogic";
const HomePage = () => {
  const { apiCallResult } = HomePageLogic();
  console.log(apiCallResult);
  return (
    <>
      <header className="home-page__header">
        <img src={Logo} alt={"Logo"} className={"home-page__logo"} />
        <input
          type={"text"}
          placeholder={"Search for products..."}
          className={"home-page__search-input"}
        />
      </header>
      <main className="home-page__main">
        <div className="home-page__main-content"></div>
      </main>
    </>
  );
};

export default HomePage;
