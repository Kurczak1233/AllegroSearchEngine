import { ProductViewModel } from "../models/ProductViewModel";
import { AxiosClient } from "./AxiosClient";

const Home = "Home";

const makeAnAllegroSearchCall = async (
  itemName: string
): Promise<ProductViewModel[]> => {
  return AxiosClient(
    "GET",
    `${Home}/GetProducts/${itemName}`,
    "https://localhost:5001"
  );
};

export { makeAnAllegroSearchCall };
