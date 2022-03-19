import { AxiosClient } from "./AxiosClient";

const Home = "Home";

const makeAnAllegroSearchCall = async (itemName: string): Promise<any> => {
  return AxiosClient(
    "GET",
    `${Home}/GetProducts/${itemName}`,
    "https://localhost:5001"
  );
};

export { makeAnAllegroSearchCall };
