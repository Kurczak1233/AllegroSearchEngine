import { useEffect, useState } from "react";
import { makeAnAllegroSearchCall } from "../../api/HomeClient";
import { ProductViewModel } from "../../models/ProductViewModel";

const HomePageLogic = () => {
  const [phrase, setPhrase] = useState<string>("");
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [apiCallResult, setApiCallResult] = useState<ProductViewModel[]>([]);

  const handleAllegroApiCallSearchResult = async () => {
    if (phrase !== "") {
      const result = await makeAnAllegroSearchCall(phrase);
      setApiCallResult(result);
    }
    setIsLoading(false);
  };

  const handleSearchClick = () => {
    setIsLoading(true);
    handleAllegroApiCallSearchResult();
  };

  useEffect(() => {
    handleAllegroApiCallSearchResult();
  }, []);
  return { apiCallResult, setPhrase, handleSearchClick, isLoading };
};

export default HomePageLogic;
