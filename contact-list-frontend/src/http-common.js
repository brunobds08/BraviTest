import axios from "axios";
export default axios.create({
  baseURL: "https://localhost:7221/api/",
  headers: {
    "Content-type": "application/json"
  }
});