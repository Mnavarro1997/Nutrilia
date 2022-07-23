<template>
    <div style="display:flex">
        <div style="display:flex" @click="$router.push(`/plan/${plan.id_Plan}`)">
        
        <img class="imgh" :src="this.plan.imageURl"/>
    
</div>

    </div>
</template>
<script>

export default {
    name: 'PlanCart',
    data(){
        return{
            plan: {}
        }
       
    },
    components: {

    },
    props:{
       idPlan : Number
    },
    created(){
        fetch(`https://localhost:44326/api/Peliculas/${this.idPlan}` , {

        })
        .then((result) => result.json())
        .then((data) => {
            this.plan = data;
            
        })
        }
        
    }  

</script>

<style>
    .imgh{
        width: 140px;
        height: 220px;
    }
    .body{
        display:flex;
        flex-direction: column;
        margin:auto;
        align-items: center;
        gap: 2em;
    }

    
</style>