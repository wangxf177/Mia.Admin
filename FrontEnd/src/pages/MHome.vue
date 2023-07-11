<template>
  <div class="root">
    <div class="left">
      <div style="position: relative">
        <div class="div1"></div>
        <div class="div2"></div>
        <div class="div3">
          <span style="display: inline-block">
            <img
              src="../assets/images/profile.jpg"
              height="85"
              width="85"
              style="border-radius: 50%"
            />
          </span>
          <span
            style="
              display: inline-block;
              padding-left: 20px;
              height: 85px;
              vertical-align: text-bottom;
            "
          >
            <span
              style="
                height: 45px;
                font-size: 24px;
                color: white;
                padding-top: 5px;
              "
            >
              <p>Bruce X Wang</p>
            </span>
            <span style="height: 45px; padding-top: 5px">
              <p>FCS-China IT-Core</p>
            </span>
          </span>
        </div>
      </div>
    </div>
    <div class="right vertical-bottom">
      <q-card dark bordered class="bg-grey-9 my-card">
        <q-card-section>
          <div class="text-h6">Our Changing Planet</div>
          <div class="text-subtitle2">by John Doe</div>
        </q-card-section>

        <q-separator dark inset size="0.1px" />

        <q-card-section>
          {{ lorem }}
        </q-card-section>

        <q-card-section>
          <div class="q-pa-md" style="max-width: 500px">
            <p>q-gutter-xs</p>
            <div class="q-gutter-xs">
              <q-btn
                color="brown"
                label="Button"
                v-for="n in 7"
                :key="`xs-${n}`"
              />
            </div>

            <p class="q-mt-md">q-gutter-sm</p>
            <div class="q-gutter-sm">
              <q-btn
                color="teal"
                label="Button"
                v-for="n in 7"
                :key="`sm-${n}`"
              />
            </div>

            <p class="q-mt-md">q-gutter-md</p>
            <div class="q-gutter-md">
              <q-btn
                color="accent"
                label="Button"
                v-for="n in 7"
                :key="`md-${n}`"
              />
            </div>

            <p class="q-mt-md">q-gutter-lg</p>
            <div class="q-gutter-lg">
              <q-btn
                color="red"
                label="Button"
                v-for="n in 7"
                :key="`lg-${n}`"
              />
            </div>

            <p class="q-mt-md">q-gutter-xl</p>
            <div class="q-gutter-xl">
              <q-btn
                color="indigo"
                label="Button"
                v-for="n in 7"
                :key="`xl-${n}`"
              />
            </div>
          </div>
        </q-card-section>
      </q-card>
    </div>
  </div>
  <q-ajax-bar ref="bar" position="top" color="green" size="1px" skaaip-hijack />
  <q-btn color="primary" label="Trigger" @click="trigger" />
</template>

<script lang="ts" setup>
import { ref } from 'vue';
const bar = ref();
const lorem = ref(
  'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.'
);
const trigger = function () {
  const barRef = bar.value;
  barRef.start();

  setTimeout(() => {
    const barRef = bar.value;
    if (barRef) {
      barRef.stop();
    }
  }, Math.random() * 3000 + 1000);
};
</script>

<style lang="scss" scoped>
.root {
  background-color: #f0f0f0;
  padding: 30px 20px 0 20px;
  &::after {
    display: block;
    content: '';
    clear: both;
  }
}
.left {
  width: 400px;
  height: 600px;
  float: left;
}
.right {
  float: left;
  background-color: white;
  width: calc(100%-500px);
  height: 500px;
}
.div1 {
  height: 65px;
  width: 360px;
  background-color: red;
}
.div2 {
  height: 65px;
  width: 360px;
  background-color: white;
}

.div3 {
  //height: 130px;
  width: 360px;
  position: absolute;
  padding: 20px 15px 20px 15px;
  top: 0;
  left: 0;
}
h5,
h6 {
  margin: 0;
  padding: 0;
}
</style>
