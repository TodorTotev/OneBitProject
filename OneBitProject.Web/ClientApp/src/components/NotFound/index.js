import React from "react";
import { Link } from "react-router-dom";

const NotFoundPage = () => {
  return (
    <div width="max" style={{backgroundImage: `url("https://cdn.dribbble.com/users/226011/screenshots/2424315/08_404.png")`}}>
      <p style={{ textAlign: "center" }}>
          <h1>404 NOT FOUND!</h1>
        <Link to='/'> Go to Home </Link>
      </p>
    </div>
  );
};

export default NotFoundPage;
