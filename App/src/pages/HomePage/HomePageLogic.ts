import { useEffect, useState } from "react";
import { makeAnAllegroSearchCall } from "../../api/HomeClient";

const HomePageLogic = () => {
  const [phrase, setPhrase] = useState<string>("narty");
  const [apiCallResult, setApiCallResult] = useState<any>();

  const handleAllegroApiCallSearchResult = async () => {
    const result = await makeAnAllegroSearchCall(phrase);
    setApiCallResult(result);
  };

  useEffect(() => {
    handleAllegroApiCallSearchResult();
  }, []);

  return { apiCallResult, setPhrase };
};

export default HomePageLogic;
