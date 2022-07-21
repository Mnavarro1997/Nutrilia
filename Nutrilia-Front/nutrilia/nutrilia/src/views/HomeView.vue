<template>
  <div class="home">
      <h2>¿QUIERES CAMBIAR TU VIDA?</h2>
    <img src = "../assets/xixi.jpg" alt="" >
    <h3>¡NOSOTRAS TE AYUDAMOS!</h3>
    <div class="somos">
      <div class="somos-item">
        <div class="foto"><img src = "../assets/nutri_deportistas.jpg" alt="" style=" width: 1350%;"></div>
        <h4>SOMOS</h4>
        <p>Nuestra misión es ayudarte a encontrar la mejor forma de alcanzar tu objetivo.</p>
      </div>
      <div class="somos-item">
        <div class="foto"><img src = "../assets/nutri_deportistas.jpg" alt="" style=" width: 1350%;" ></div>
        <h4>NOSOTROS</h4>
        <p>Nuestra misión es ayudarte a encontrar la mejor forma de alcanzar tu objetivo.</p>
      </div>
    </div>
    <div class = "plans" v-for="plan in plans " :key="plan.id_Plan">
    <div class="plan-item">
      <p>{{plan.name}}</p>
      <img class="imgenPlan" :src="plan.imageURl" alt="">
      <p>{{plan.price}} € </p>
    </div>
    <div class="comprar">
                <router-link :to="{ name: 'Home', params: { id: plan.id_Plan} }">
                <b-button class="boton">
                  <h1>Detalles</h1>
                </b-button>
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

}
}
</script>
<style>

.home{
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background-color: rgb(132, 218, 132);
}
.somos{
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  margin-top: 10px;
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
  border: 4px solid rgb(90, 89, 89);
  margin-top: 5px;
  background-color: rgb(240, 230, 230);
  box-shadow: rgba(0, 0, 0, 0.17) 0px -23px 25px 0px inset, rgba(0, 0, 0, 0.10) 0px -36px 30px 0px inset, rgba(0, 0, 0, 0.1) 0px -79px 40px 0px inset, rgba(0, 0, 0, 0.06) 0px 2px 1px, rgba(0, 0, 0, 0.09) 0px 4px 2px, rgba(0, 0, 0, 0.09) 0px 8px 4px, rgba(0, 0, 0, 0.09) 0px 16px 8px, rgba(0, 0, 0, 0.09) 0px 32px 16px;}
.plan-item{
  padding: 1rem;
  text-align: center;
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
</style>