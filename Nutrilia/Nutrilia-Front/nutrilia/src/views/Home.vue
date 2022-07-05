<template>
  <div>
    <header>
      <img src="../assets/logo.png" style="width: 200px" />
      <input
        style="margin: auto"
        id="input-search"
        type="text"
        class="form-control"
        v-model="search"
        placeholder="Search..."
      />
      <div class="nickname" style="margin: auto; color: black;">
        <p>Bienvenido {{ user.nick }}</p>
      </div>

      <div id="app" style="margin: auto">
        <div>
          <div>
            <router-link style="text-decoration: none; color:orangered" to="/"
              >Cerrar sesión</router-link
            >
          </div>
        </div>
        <router-view />
      </div>
    </header>
    <div class="container">
      <div class="inner">
        <div id="one" class="item first">
          Bienvenido a Onlyfilms, la página web dónde cada vez mas usuarios
          acuden a documentarse sobre los nuevos estrenos
        </div>
        <div id="two" class="item second">
          Con ayuda de los usuarios te ayudaremos a elegir los proximos titulos
          que quieres ver, pero quieres informarte primero
        </div>
        <div id="three" class="item third">
          Deja tus puntuaciones y comentarios en las películas que hayas visto
          para ayudar a más usuarios
        </div>
        <div id="four" class="item fourth">
          Guarda en la Wishlist las películas que te interesan, para verlas
          próximamente
        </div>
      </div>
    </div>

    <div class="movil">
      <div class="izq">
        <select @change="onChange($event)" v-model="key" style="border-radius:5px;color:orangered">
          <option selected hidden value="">Elige tu género favorito</option>
          <option v-for="genero in generos" :key="genero.id" :value="genero.id">
            {{ genero.name }}
          </option>
        </select>
        <div>
          <ul class="ulge" style="margin-top: 20px">
            <li v-for="id in listaIds" :key="id">
              <div class="movie-cardge">
                <Peliculage :idPelicula="id" />
              </div>
            </li>
          </ul>
        </div>
      </div>
      <div class="mid">
        <div style="width: 100%">
          <button
            class="botonvermas"
            v-show="!showMore"
            @click="showMore = true"
          >
            Ver más
          </button>

          <ul v-if="!showMore">
            <li
              class="primelist"
              v-for="(pelicula, index) in searchPelis"
              :key="pelicula.id"
            >
              <template v-if="index <= 6">
                <div class="movie-card">
                  <Pelicula :idPelicula="pelicula.id" />
                </div>
              </template>
            </li>
          </ul>

          <ul v-else>
            <li
              class="primelist"
              v-for="pelicula in searchPelis"
              :key="pelicula.id"
            >
              <div class="movie-card">
                <Pelicula :idPelicula="pelicula.id" />
              </div>
            </li>
          </ul>
        </div>
      </div>
      <div class="der">
        <button class="cubo" @click="$router.push(`/pelicula/${aleatorio}`)">
          Prueba nuestro sistema de pelicula aleatoria
        </button>

        <a
          style="
            margin-top: 40px;
            margin-bottom: 20px;
            text-decoration: none;
            color: orangered;
          "
          href="/wishlist"
          >&#10084; Carrito &#10084;
        </a>
        <li
          style="list-style: none; padding-bottom: 15px"
          v-for="pelicula in peliculaswl"
          :key="pelicula.idPelicula"
        >
          <div class="movie-cardwish">
            <Peliculawlhome :idPelicula="pelicula.idPelicula" />
          </div>
        </li>
      </div>
    </div>
    <footer style="display: flex; width: 100%; height: 200px; margin-top: 40px">
      <div
        class="respo"
        style="display: flex; width: 33%; flex-direction: column"
      >
        <h3 style="display: flex; height: 25%; margin: auto">
          Links de interes
        </h3>
        <a
          href=""
          style="
            display: flex;
            text-decoration: none;
            height: 25%;
            margin: auto;
          "
          >Funcionamiento</a
        >
        <a
          href=""
          style="
            display: flex;
            text-decoration: none;
            height: 25%;
            margin: auto;
          "
          >Soporte</a
        >
        <a
          href=""
          style="
            display: flex;
            text-decoration: none;
            height: 25%;
            margin: auto;
          "
          >Ayuda</a
        >
      </div>

      <div
        class="respo"
        style="display: flex; width: 33%; flex-direction: column"
      >
        <h3 style="display: flex; height: 25%; margin: auto">Sobre nosotros</h3>
        <p style="display: flex; height: 25%; margin: auto">Zaragoza, España</p>
        <p style="display: flex; height: 25%; margin: auto">
          info@onlyfilms.es
        </p>
        <p style="display: flex; height: 25%; margin: auto">+34 654 789 012</p>
      </div>

      <div
        class="respo"
        style="display: flex; width: 33%; flex-direction: column"
      >
        <h3 style="display: flex; height: 25%; margin: auto">Redes sociales</h3>
        <div style="display: flex; height: 37.5%; margin: auto; gap: 30px">
          <a style="display: flex; width: 50%; margin: auto" href=""
            ><img
              style="width: 25px; height: 25px"
              src="../assets/logotipo-de-instagram.png"
              alt=""
          /></a>
          <a style="display: flex; width: 50%; margin: auto" href=""
            ><img
              style="width: 25px; height: 25px"
              src="../assets/whatsapp.png"
              alt=""
          /></a>
        </div>
        <div style="display: flex; height: 37.5%; margin: auto; gap: 30px">
          <a style="display: flex; width: 50%; margin: auto" href=""
            ><img
              style="width: 25px; height: 25px"
              src="../assets/gorjeo.png"
              alt=""
          /></a>
          <a style="display: flex; width: 50%; margin: auto" href=""
            ><img
              style="width: 25px; height: 25px"
              src="../assets/tik-tok.png"
              alt=""
          /></a>
        </div>
      </div>
    </footer>
  </div>
</template>


<script>
import Pelicula from "../components/Pelicula.vue";
import Peliculawlhome from "../components/Peliculawlhome.vue";
import Peliculage from "../components/Peliculage.vue";

export default {
  name: "Home",

  data() {
    return {
      peliculas: [],
      wish: {},
      generos: [],
      key: "",
      listaIds: [],
      showMore: false,
      peliculaswl: [],
      aleatorio: Math.round(Math.random() * 39),
      search: "",
    };
  },

  created() {
    fetch("https://localhost:44326/api/Peliculas", {
      headers: { "Content-Type": "application/json" },
    })
      .then((result) => result.json())
      .then((data) => {
        this.peliculas = data;
      });
    fetch("https://localhost:44326/api/Generoes", {
      headers: { "Content-Type": "application/json" },
    })
      .then((result) => result.json())
      .then((data) => {
        this.generos = data;
      });
    fetch("https://localhost:44326/userWishlist/" + this.user.id, {})
      .then((result) => result.json())
      .then((data) => {
        this.peliculaswl = data;
      });
  },
  //get user from store
  computed: {
    user() {
      return this.$store.getters.getCurrentUser;
    },
    searchPelis() {
      return this.peliculas.filter((pelicula) => {
        return pelicula.name.toLowerCase().includes(this.search.toLowerCase());
      });
    },
  },
  methods: {
    addWishlist(id_Pelicula) {
      let item = JSON.stringify({
        idPelicula: id_Pelicula,
        idUsuario: this.user.id,
      });

      fetch("https://localhost:44326/api/Wishlists", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: item,
      });
    },

    eliminarDeWishlist(id_Pelicula) {
      fetch(
        "https://localhost:44326/getWishlistBy/" +
          this.user.id +
          "/" +
          id_Pelicula,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      )
        .then((result) => result.json())
        .then((data) => {
          fetch("https://localhost:44326/api/Wishlists/" + data[0].id, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
          });
        });
    },

    onChange(event) {
      this.key = event.target.value;
      fetch("https://localhost:44326/getPelisBy/" + this.key)
        .then((result) => result.json())
        .then((data) => {
          this.listaIds = data;
        });
    },
  },
  components: {
    Pelicula,
    Peliculawlhome,
    Peliculage,
  },
};
</script>

<style>
.movil {
  display: flex;
  margin-top: 40px;
}
.img {
  width: 100px;
  height: 100px;
}
ul {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  list-style: none;
  gap: 2em;
  margin: auto;
  padding-left: 0px !important;
}
.ulge {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  list-style: none;
  padding: 0;
  margin: 0;
  gap: 2em;
}

.primelist:first-child {
  grid-column: 1/3;
  grid-row: 1/3;
}
.primelist:first-child img {
  width: 100%;
  height: 500px;
}
.primelist:first-child .movie-card .body {
  display: none;
}
.primelist:first-child .movie-card {
  max-width: 333px;
}

.primelist:nth-child(2) {
  grid-column: 3/5;
  grid-row: 1/3;
}
.primelist:nth-child(2) img {
  height: 240px;
  width: 200px;
}
.primelist:nth-child(3) {
  grid-column: 3/5;
  grid-row: 2/3;
}
.primelist:nth-child(3) img {
  width: 200px;
  height: 240px;
  overflow: hidden;
}
.primelist:nth-child(3) body {
  margin: auto;
}

.izq {
  display: flex;
  width: 15%;
  flex-direction: column;
  align-items: center;
}
.mid {
  display: flex;
  width: 70%;
}
.der {
  display: flex;
  width: 15%;
  flex-direction: column;
  align-items: center;
  margin-left: 15px auto;
}

.movie-card {
  background-color: #fff;
  border-radius: 10px;
  overflow: hidden;
  box-shadow: 0px 4px 5px 0px #888;
  margin: 0 auto;
  cursor: pointer;
  min-height: 215px !important;
}

.movie-cardwish {
  background-color: #fff;
  border-radius: 10px;
  overflow: hidden;
  box-shadow: 0px 4px 5px 0px #888;
  margin: 0 auto;
  cursor: pointer;
  width: 200px !important;
  min-height: 100px !important;
}
.movie-cardge {
  background-color: #fff;
  border-radius: 10px;
  overflow: hidden;
  box-shadow: 0px 4px 5px 0px #888;
  margin: 0 auto;
  width: 75px !important;
  height: 110px !important;
}
.movie-cardge img {
  height: 80px;
  width: 75px;
}
.movie-card:hover {
  box-shadow: 0px 0px 10px 0px #888;
}

header {
  padding: 10px;
  background-color: #fff;
  border-bottom: 1px solid #ccc;
  display: flex;
  justify-content: space-between;
}
.form-control {
  border-radius: 0px;
  border: 1px solid #ccc;
  padding: 5px;
  margin-bottom: 10px;
  width: 50% !important;
}
.cubo {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 80px;
  font-size: large;
  border-radius: 25px;
  border: 2px black solid;
}
.botonvermas {
  position: absolute;
  top: 1050px;
  left: 47.9%;
  border-radius: 5px;
  color: orangered;
}

.container,
.item {
  width: 100%;
  height: 50px;
  line-height: 50px;
}
.container {
  margin: 0 auto;
  height: 50px;
  text-align: center;
  position: relative;
  overflow: hidden;
  border-radius: 10px;
  font-size: 25px;
}
.item {
  position: absolute;
  top: 0;
  left: 500px;
}
.first {
  left: 0;
  opacity: 1;
  z-index: 0;
}

.first {
  animation: cycleone 30s ease-in-out infinite;
}
.second {
  animation: cycletwo 30s ease-in-out infinite;
}
.third {
  animation: cyclethree 30s ease-in-out infinite;
}
.fourth {
  animation: cyclefour 30s ease-in-out infinite;
}
@keyframes cycleone {
  0% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
  20% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
  25% {
    left: -500px;
    opacity: 0;
    z-index: 0;
  }
  26% {
    left: -500px;
    opacity: 0;
    z-index: -1;
  }
  27% {
    left: 500px;
    opacity: 0;
    z-index: -1;
  }
  95% {
    left: 500px;
    opacity: 0;
    z-index: 0;
  }
  100% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
}
@keyframes cycletwo {
  0% {
    left: 500px;
    opacity: 0;
  }
  20% {
    left: 500px;
    opacity: 0;
  }
  25% {
    left: 0px;
    opacity: 1;
  }
  45% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
  50% {
    left: -500px;
    opacity: 0;
    z-index: 0;
  }
  51% {
    left: 500px;
    opacity: 0;
    z-index: -1;
  }
  100% {
    left: 500px;
    opacity: 0;
    z-index: -1;
  }
}
@keyframes cyclethree {
  0% {
    left: 500px;
    opacity: 0;
  }
  45% {
    left: 500px;
    opacity: 0;
    z-index: -1;
  }
  50% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
  70% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
  75% {
    left: -500px;
    opacity: 0;
    z-index: 0;
  }
  76% {
    left: 500px;
    opacity: 0;
    z-index: -1;
  }
  100% {
    left: 500px;
    opacity: 0;
    z-index: -1;
  }
}
@keyframes cyclefour {
  0% {
    left: 500px;
    opacity: 0;
    z-index: -1;
  }
  70% {
    left: 500px;
    opacity: 0;
    z-index: 0;
  }
  75% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
  95% {
    left: 0px;
    opacity: 1;
    z-index: 0;
  }
  100% {
    left: -500px;
    opacity: 0;
    z-index: 0;
  }
}

@media (max-width: 360px) {
  .der {
    display: none !important;
    order: 1;
  }

  .izq {
    order: 2;
  }
  .primelist {
    display: flex !important;
    justify-content: center !important;
  }
  ul {
    display: flex !important;
    flex-direction: column !important;
    margin: auto !important;
  }
  .movil {
    display: flex !important;
    justify-content: center !important;
    align-items: center !important;
    max-width: 360px !important;
    margin: auto;
    flex-direction: column;
    padding-top: 20px;
  }
  .mid {
    width: 90% !important;
    margin: auto !important;
  }
  .movie-card {
    min-width: 300px !important;
    margin: auto !important;
  }
  .botonvermas {
    top: 2240px !important;
    left: 40% !important;
  }
  .container {
    display: none !important;
  }
  .nickname {
    display: none !important;
  }
  footer {
    flex-direction: column !important;
    height: 500px !important;
    justify-content: center !important;
    margin: auto !important;
  }
  .respo {
    width: 100% !important;
    height: 100px !important;
  }
}
</style>