/* eslint-disable @typescript-eslint/no-explicit-any */
import axios, { Method } from "axios";

/* eslint-disable @typescript-eslint/no-unused-vars */
const AxiosClient = async (
  method: Method,
  endpoint: string,
  applicationBase: string
): Promise<any> => {
  const requestResult = await axios({
    method: method,
    url: `${applicationBase}/${endpoint}`,
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
    },
  });

  return requestResult.data;
};
export { AxiosClient };
