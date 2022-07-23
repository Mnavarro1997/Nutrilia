<template>
 <div>
      <h1>Carrito de la compra de {{user.name}}</h1>
      hola don pepito

  <ul>
      <li v-for="plan in plans"
      :key="plan.id_Plan"> 
        <div class="plan-cart">

        <PlanCart :id_Plan="plan.id_Plan" />
        <button @click="eliminarDeCarrito(plan.id_Plan)">Eliminar del carrito</button>
      </div>  
      </li>
  </ul>
  </div>

</template>
<script>
import PlanCart from '../components/PlanCart.vue'
export default {
    name: "CartView",
    data() {
        return {
            plans: [],
        };
    },
    created() {
        fetch("https://localhost:44338/userCart/" + this.user.id_User, {})
            .then((result) => result.json())
            .then((data) => {
            this.plans = data;
            
        });
    },
    //get user from store
    computed: {
        user() {
            return this.$store.getters.getCurrentUser;
        }
    },
    methods:{
        eliminarDeWishlist(id_Plan) {
      fetch(
        "https://localhost:44338/getCartBy/" +
          this.user.id_User +
          "/" +
          id_Plan,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      )
        .then((result) => result.json())
        .then((data) => {
          fetch("https://localhost:44338/api/Cart/" + data[0].id, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
            
          }).then(this.$router.go(0),alert("Plan eliminado correctamente"));
        });
    },
    },

    components: { PlanCart }
};
</script>
<style>
.movie-cardwl {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 200px;
  height: 300px;
  margin: 10px;
  border-radius: 10px;
  background-color: #f2f2f2;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  overflow: hidden;
}
.movie-cardwl img{
 
  width: 200px;
  height: 278px;

 }
 .movie-cardwl button{
 
  width: 200px;
  height: 278px;
  border: 0px;
  background-color: black;
  color: #f2f2f2;
  font-size: 15px;
  cursor: pointer;
  

 }
</style>