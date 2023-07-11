<template>
  <div class="q-pa-md">
    <q-table
      title="用户管理"
      :rows="rows"
      :columns="columns"
      row-key="name"
      :pagination="{ rowsPerPage: 8 }"
      table-header-class="bg-secondary"
    >
      <template v-slot:top>
        <q-btn-group outline glossy push unelevated>
          <q-btn
            color="secondary"
            icon="add"
            label="新增"
            @click="addDialog = true"
            push
            dense
          />
          <q-btn color="secondary" icon="edit" label="修改" push dense />
          <q-btn color="secondary" icon="delete" label="删除" push dense />
          <q-btn color="secondary" icon="upload" label="导入" push dense />
          <q-btn color="secondary" icon="download" label="导入" push dense />
        </q-btn-group>
      </template>
    </q-table>

    <q-dialog v-model="addDialog">
      <q-card style="min-width: 350px">
        <q-card-section>
          <div class="text-h6">Your address</div>
        </q-card-section>

        <q-card-section class="q-pt-none">
          <q-input
            dense
            v-model="address"
            autofocus
            @keyup.enter="addDialog = false"
          />
        </q-card-section>

        <q-card-actions align="right" class="text-primary">
          <q-btn flat label="Cancel" v-close-popup />
          <q-btn flat label="Add address" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script lang="ts" setup>
import { onMounted, ref } from 'vue';

onMounted(() => {
  console.log('user pages has mounted!');
});
const address = ref('');
const addDialog = ref(false);
const columns = ref([
  {
    name: 'name',
    required: true,
    label: '角色编号',
    align: 'center',
    field: 'name',
  },
  {
    name: 'calories',
    align: 'center',
    label: '角色名称',
    field: 'calories',
  },

  {
    name: 'calcium',
    label: '操作',
    field: 'calcium',
    align: 'center',
  },
]);

const rows = ref([
  {
    name: 'Frozen Yogurt',
    calories: 159,
    fat: 6.0,
    carbs: 24,
    protein: 4.0,
    sodium: 87,
    calcium: '14%',
    iron: '1%',
  },
  {
    name: 'Ice cream sandwich',
    calories: 237,
    fat: 9.0,
    carbs: 37,
    protein: 4.3,
    sodium: 129,
    calcium: '8%',
    iron: '1%',
  },
  {
    name: 'Eclair',
    calories: 262,
    fat: 16.0,
    carbs: 23,
    protein: 6.0,
    sodium: 337,
    calcium: '6%',
    iron: '7%',
  },
  {
    name: 'Cupcake',
    calories: 305,
    fat: 3.7,
    carbs: 67,
    protein: 4.3,
    sodium: 413,
    calcium: '3%',
    iron: '8%',
  },
  {
    name: 'Gingerbread',
    calories: 356,
    fat: 16.0,
    carbs: 49,
    protein: 3.9,
    sodium: 327,
    calcium: '7%',
    iron: '16%',
  },
  {
    name: 'Jelly bean',
    calories: 375,
    fat: 0.0,
    carbs: 94,
    protein: 0.0,
    sodium: 50,
    calcium: '0%',
    iron: '0%',
  },
  {
    name: 'Lollipop',
    calories: 392,
    fat: 0.2,
    carbs: 98,
    protein: 0,
    sodium: 38,
    calcium: '0%',
    iron: '2%',
  },
  {
    name: 'Honeycomb',
    calories: 408,
    fat: 3.2,
    carbs: 87,
    protein: 6.5,
    sodium: 562,
    calcium: '0%',
    iron: '45%',
  },
  {
    name: 'Donut',
    calories: 452,
    fat: 25.0,
    carbs: 51,
    protein: 4.9,
    sodium: 326,
    calcium: '2%',
    iron: '22%',
  },
  {
    name: 'KitKat',
    calories: 518,
    fat: 26.0,
    carbs: 65,
    protein: 7,
    sodium: 54,
    calcium: '12%',
    iron: '6%',
  },
]);
</script>
