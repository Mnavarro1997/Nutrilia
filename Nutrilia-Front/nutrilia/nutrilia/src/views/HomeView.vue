<template>
  <div class="home">
      <h2>¿QUIERES CAMBIAR TU VIDA?</h2>
    <div class="slider-container">  
    <img
    class="slider-item"
    src="../assets/corazon.jpg"
  />
  <img
    class="slider-item"
    src="../assets/sandia.jpg"
  />
</div> 
    <h3>¡NOSOTRAS TE AYUDAMOS!</h3>
    <h1>QUIENES SOMOS:</h1>
    <div class="somos" >
      <div class="somos-item">
        <div class="foto"><img src = "../assets/ines.png" alt="" style=" width: 850%;   border: 3px solid black;
  padding: 15px"></div>
        <h2>INES SALDAÑA</h2>
        <p>Graduada en ciencias de la actividad física y el deporte. Máster en educación secundaria y máster en nutrición y salud. 
          Amante de los deportes de montaña y los deportes colectivos.
          Creadora del perfil "AFicionate" para la promoción de la actividad física y deporte  desde nuevas plataformas.</p>
      </div>
      <div class="somos-item" >
        <div class="foto"><img src = "../assets/carmen.png" alt="" style=" width: 600%;   border: 3px solid black;
  padding: 15px"></div>
        <h2>CARMEN CERVERA</h2>
        <p>Graduada en nutrición humana y dietética por la Universidad de Zaragoza. Máster en calidad, seguridad y tecnología de los alimentos.
Carmen habla de la importancia de una buena educación nutricional desde que somos pequeños.  Nutrición clínica en consulta, tratando diferentes casos como perdida de peso, patologias digestivas y hormonales, nutrición deportiva... siempre acompañado de actividad física dirigida por un profesional!
        </p>
      </div>
    </div>
    <p style = "font-size: 20px; font-weight: bold;">¿QUIERES CONOCER NUESTROS PLANES?</p>
    <div class = "plans" v-for="plan in plans " :key="plan.id_Plan">
    <div class="plan-item">
      <p>{{plan.name}}</p>
      <img class="imgenPlan" :src="plan.imageURl" alt="">
      <p>{{plan.price}} € </p>
    </div>
    <div class="comprar">
                <router-link to="/products">
                <b-button class="boton">
                  <h1>Detalles</h1>
                </b-button>
                </router-link>
            </div>
    </div>
    <h2>NUESTRAS RECETAS SEMANALES DESTACADAS: </h2>
    <div class = "recipes" v-for="recipe in recipes " :key="recipe.id_recipe">
      
      <div class = "recipe-item">
        <router-link to="/about">
          <p>{{recipe.name}}</p>
      <img class="imgenPlan" :src="recipe.url" alt="">
        </router-link>
      
      </div>
    </div>
  </div> 

</template>

<script>
// @ is an alias to /src


export default {
  name: 'HomeView',

  created() {
      fetch('https://localhost:44338/api/Plans')
        .then(result => result.json())
        .then(data => this.plans = data)
        fetch('https://localhost:44338/api/Recipes')
        .then(result => result.json())
        .then(data => this.recipes = data)
    },
    data() {
    return {
      plans: [],
      recipes:[],
      data: []
    };
},
methods:{
editar(id_recipe){
      this.$router.push('/recipe/' + id_recipe);
    },
    viewProduct(recipe){
      this.recipe = recipe
      this.active.recipe_drawer = true;
      console.log(this.recipe);
    },
    closeProductDrawer(){
      this.active.recipe_drawer = false;
    },
    getProduct(id_recipe){
      let data = fetch('https://localhost:44330/api/Recipes/' + id_recipe)
      .then(response=> response.json())
      .then(data=> data.filter(recipe=> recipe.id_recipe == id_recipe))
      .then(data=> {
          if(data.length > 0){
              return data[0]
          }else{
              return null
          }
      })
      return data
}
}
}
</script>
<style>

.home{
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background-color: rgb(112, 187, 112);
}
.slider-container {
  display: flex;
  width: 80%;
  height: 600px;
  overflow-x: scroll;
}

.slider-container img {
  flex: 0 0 80%;
  width: 80%;
  object-fit: cover;
}
.somos{
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  margin-top: 10px;
}
.somos p{
  font-size: 18px;
  font-weight: bold;
  width: 60%;
  
}
.foto{
  width: 7%;
  margin-left: 17px;
}
.plans{
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 25%;
  flex-wrap: wrap;
  flex-basis: 2;
  border: 4px solid rgb(90, 89, 89);
  margin-top: 5px;
  background-color: rgb(240, 230, 230);
  box-shadow: rgba(0, 0, 0, 0.17) 0px -23px 25px 0px inset, rgba(0, 0, 0, 0.10) 0px -36px 30px 0px inset, rgba(0, 0, 0, 0.1) 0px -79px 40px 0px inset, rgba(0, 0, 0, 0.06) 0px 2px 1px, rgba(0, 0, 0, 0.09) 0px 4px 2px, rgba(0, 0, 0, 0.09) 0px 8px 4px, rgba(0, 0, 0, 0.09) 0px 16px 8px, rgba(0, 0, 0, 0.09) 0px 32px 16px;}
.plan-item{
  padding: 1rem;
  text-align: center;
}
.plan-item p {
  font-size: 15px;  
  font-weight: bold;
  color: rgb(148, 12, 12);
}
.comprar {
    text-align: center;
}
.boton {
    height: 20px;
    font-family: 'New Super Mario Font U', sans-serif;
    color: rgb(0, 0, 0);
    text-shadow: 3px 0 0 rgb(255, 255, 255), -3px 0 0 rgb(255, 255, 255), 0 3px 0 rgb(255, 255, 255), 0 -3px 0 rgb(255, 255, 255), 2px 2px rgb(255, 255, 255), -2px -2px 0 rgb(255, 255, 255), 2px -2px 0 rgb(255, 255, 255), -2px 2px 0 rgb(255, 255, 255);
    font-size: 10px;
    box-shadow: 2px 2px 2px 1px rgba(61, 61, 61, 0.4);
    width: 100px;
}
.imgenPlan{
    box-shadow: 4px 4px 4px 2px rgba(92, 90, 90, 0.2);
    border-radius: 5px;
    height: 150px;
    margin-left: 20px;
}
.recipes{
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  flex-basis: 2;
}
.recipes p{
font-size: medium;
font-weight: bold;
}
</style>