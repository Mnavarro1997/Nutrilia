<template>
  <div id="app">
    <nav style = "display : flex; flex-direction: row;justify-content: space-between;">
      <router-link to="/about"><img src = "./assets/user.png" alt="header" style="height: 55px; margin-right: 10px;"></router-link> <!--inicio de sesion y registro -->
      <router-link to="/"><img src = "./assets/logo.png" alt="header" style="height: 90px; margin-left:30px; display: float: left;"></router-link> 
      <router-link to="/about"> <img src = "./assets/cart.png" alt="header" style="height: 55px; margin-right: 10px;"></router-link> <!--carrito de la compra -->
    </nav>
    <router-view/>
    <nav>
      <div id = "footer">
        <p>NUTRILIA</p>
        <b>Copyright © 2022</b>
      </div>
    </nav>
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #030303;
  width:100%;
  height:100px;
  background-color: #ffffff;
}

nav {
  padding: 3px;
  margin: 0 auto;
}

nav a {
  font-weight: bold;
  color: #1f83e7;
}

nav a.router-link-exact-active {
  color: #36d68e;
  margin-right: 20px;
}
#footer{

  display: flex;
  flex-direction: column;
  margin: 0 auto;
  margin-top: 200px;
}
.footer p  {
  font-size: 20px;
  font-weight: bold;
  font-family: 'Courier New', Courier, monospace;
  margin-inline: 5px;
}
</style>
