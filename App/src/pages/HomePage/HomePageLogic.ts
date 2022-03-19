import { useEffect, useState } from "react";
import { makeAnAllegroSearchCall } from "../../api/HomeClient";
import { ProductViewModel } from "../../models/ProductViewModel";

const HomePageLogic = () => {
  const [phrase, setPhrase] = useState<string>("narty");
  const [apiCallResult, setApiCallResult] = useState<ProductViewModel[]>([]);

  const handleAllegroApiCallSearchResult = async () => {
    const result = await makeAnAllegroSearchCall(phrase);
    setApiCallResult(result);
  };

  const handleSearchClick = () => {
    handleAllegroApiCallSearchResult();
  };

  useEffect(() => {
    handleAllegroApiCallSearchResult();
  }, []);
  return { apiCallResult, setPhrase, handleSearchClick, phrase };
};

export default HomePageLogic;
