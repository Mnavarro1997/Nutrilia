<template>
<header>
        <nav id="navArea">
            <router-link to="/">
            <div class="nutrilia">
              <div class = "img-header">
                <a href="#">
                  <img style="height: 4px;" src="Nutrilia\Nutrilia-Front\nutrilia\src\images\logo.png" alt="LOGO">
                </a>
               </div> 
                <p style="color: #000000;">Iniciar Sesión</p>
                <p style="color: #000000;">Registro</p>
            </div>
            </router-link>
        </nav>
    </header>
</template>
<script>
export default {
  name: 'NavComp'
}
</script>
<style>
#navArea {
    display: flex;
    margin: 0 auto;
    margin-top: 2%;
    border-radius: 4px;
    width: 100%;
    height: 100px;
    box-shadow: 3px 3px 3px 2px rgba(132, 243, 122, 0.7);
    background-color: #88e288;
    
}
.img-header{
  display: flex;
  margin: 0 auto;
  margin-top: 2%;
}
.nutrilia {
    display: flex;
    vertical-align: middle;
    line-height: 9px;
    margin-right: 10px;
    width: 100%;
}

.nutrilia p {
    font-size: 20px;
    font-weight: bold;
    font-family: 'Courier New', Courier, monospace;
    margin-inline: 5px;
}

.hamburger-menu h1 {
    text-align: right;
    font-size: 25px;
    background-color: red;
    text-shadow: 2px 0 0 white, -2px 0 0 white, 0 2px 0 white, -2px 0 white, 1px 1px white, -1px -1px 0 white, 1px -1px 0 white, -1px 1px 0 white;
}

main {
    text-align: center;
    margin: 0 auto;
}

footer{
    text-align: center;
    background: rgb(255, 255, 255);
    background: linear-gradient(180deg, rgba(255, 255, 255, 1) 5%, rgba(158, 158, 158, 1) 45%, rgba(0, 0, 0, 1) 100%);
}
footer h3{
    color: rgb(255, 200, 0);
    text-shadow: 1px 0 0 rgb(255, 0, 0);
}

@media only screen and (max-width: 600px) {
body{
    width: 100%;
}

}
</style>