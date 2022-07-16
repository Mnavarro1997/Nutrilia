<template>
<div id = "app">
  <NavComp />
  <div class = "message">
    <div class = "container">
      <div class = "row">
        <div class = "col-md-12">
          <h1>Bienvenido a Nutrilia</h1>
          <p>
            Lorem ipsum dolor sit amet, consectetur adipisicing elit.
            Quisquam, quidem, quisquam.
          </p>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import NavComp from './components/NavComp.vue'
export default {
  name: 'App',
  components: {
    NavComp
  }
}
</script>

<style>

</style>
