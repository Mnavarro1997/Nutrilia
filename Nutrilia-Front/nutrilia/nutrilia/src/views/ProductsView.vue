<template>
    
<div class = a>
    
<div class = "plans" v-for="plan in plans " :key="plan.id_Plan">
<H3>NUESTROS PLANES:</H3>
    <div class="plan-item">
      <p>{{plan.name}}</p>
      <img class="imgenPlan" :src="plan.imageURl" alt="">
      <p>{{plan.description}}</p>
      <p>{{plan.price}} € </p>
    </div>
    <div class="comprar">
                <router-link to="/cart">
                <b-button class="boton">
                  <h1>Comprar</h1>
                </b-button>
                </router-link>
            </div>
    </div>
    </div>
</template>
<script>
export default {
  name: 'ProductsView',

  created() {
      fetch('https://localhost:44338/api/Plans')
        .then(result => result.json())
        .then(data => this.plans = data)
    },
    data() {
    return {
      plans: [],
      data: []
    };
},
}
</script>
<style>
.a{
    display: flex;
    margin: auto;
    gap: 2em;
    flex-basis: 2;
    flex-wrap: wrap;
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
</style>