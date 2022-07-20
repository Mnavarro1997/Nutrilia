<template>
<div class="nut">
    <p>BIENVENIDA A NUTRILIA</p>
    <b>Novedades</b>
    <lu>
      <li>
        <div class="recipes" v-for="recipe in recipes" :key="recipe.id_recipe" >
      <div class="divEachProduct">
        <b><p>{{recipe.name}}</p></b>
        <img class="imgenCategoriaa" :src="recipe.url" alt="">
        <p>{{recipe.description}}</p>
          <!--<div class="divVerProductos">
              <div class="comprar">
                <router-link :to="{ name: 'Product', params: { id: product.id} }">
                <b-button class="boton">
                  <h1>Detalles</h1>
                </b-button>
                </router-link>
              </div>    
          </div>
           
           PARA QUE TE LLEVE A ESE SITIO
           v-on:click="editar(recipe.id_recipe)"
           -->
      </div>
    </div>
      </li>
    </lu>
    
  </div>
</template>
<script>
export default {
  name: 'AboutView',

  created() {
      fetch('https://localhost:44338/api/Recipes')
        .then(result => result.json())
        .then(data => this.recipes = data)
    },
    data() {
    return {
      recipes: [],
      data: []
    };
  },
  methods: {
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
  },
  asyncComputed:{
    async quantity(){
      let p = await this.getProduct(this.recipe.id_recipe)
      console.log(p);
      return p.quantity
    }       
  },
  computed:{
    rows() {
        return this.items.length
      },
    actualItems(){
      return this.items.slice(this.currentPage*6 -6, this.currentPage*6)
    }
  }
}
</script>
<style>
.nut{
  background-color: rgb(132, 218, 132);
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 800px;
}
.nut p{
    font-size: 20px;
    font-weight: bold;
    font-family: 'Courier New', Courier, monospace;
    margin-inline: 5px;

}
.recipes{
      display: flex;
    flex-direction: row;
    width: 100%;
    height: 250px;
    justify-content: space-around;
    align-items: center;
    background-color: rgb(132, 218, 132);
    margin: 0 auto;
    box-shadow: 4px 4px 4px 2px rgb(0 0 0 / 30%);
    border-radius: 5px;
}
.divEachProduct{
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 80px;
  justify-content: space-around;
  align-items: center;
  background-color: rgb(132, 218, 132);
}
.divEachProduct p{
  font-size: 10px;
  font-weight: bold;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}
.imgenCategoriaa{
  width: 35%;
  height: 190px;
}

.recipes b{
  font-size: 12px;
  font-weight: bold;
  font-family: 'Courier New', Courier, monospace;
 
}
</style>