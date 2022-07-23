<template>
<div class="box">
      <form @submit.prevent="loginUser">
        <h1>Login</h1>
        <input type="text" placeholder="Email" v-model="email" required />
        <input
          type="password"
          placeholder="Password"
          v-model="password"
          required
        />
        <button type="submit" class="loginbtn">Iniciar Sesión</button>
      </form>
        <div style="margin-top: 10px">
          <a style="text-decoration: none" href="/registro"
            >¿Aún no te has unido con nosotras? REGISTRATE</a>
      </div>
    </div>

</template>

<script>
export default {
  name: 'LoginView',
  data() {
    return {
      email: "",
      password: "",
    };

},
methods:
{
    loginUser() {
      fetch("https://localhost:44338/api/Users/api/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          email: this.email,
          password: this.password,
        }),
      }).then((response) => {
        if (response.status === 200) {
          response.json().then((data) => {
            this.$store.commit("setCurrentUser", data);
            this.$router.push("/");
          });

          alert("Login correcto");

          this.$router.push("/");
        } else {
          alert("Los datos son incorrectos o no existe el correo");
          //reject
        }
      });
    },
}
}
</script>
<style>
.box {
  width: 100%;
  max-width: 500px;
  margin: 0 auto;
  border: 1px solid black;
  border-radius: 10px;
  padding: 16px;
  margin-top: 15px;
}
* {
  box-sizing: border-box;
}
.loginbtn {
  background-color: #28cf6d;
  color: white;
  padding: 16px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}
</style>