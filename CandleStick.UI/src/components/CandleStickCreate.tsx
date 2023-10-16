import {
  Container,
  Heading,
  FormControl,
  FormLabel,
  Input,
  Button,
  Box,
  Text,
} from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import CandleStickService from "../services/candleStickService";

const schema = z.object({
  openPrice: z
    .number({ invalid_type_error: "Please enter a price" })
    .min(0, "The Price can not be a negative number."),
  closePrice: z
    .number({ invalid_type_error: "Please enter a price" })
    .min(0, "The Price can not be a negative number."),
  lowPrice: z
    .number({ invalid_type_error: "Please enter a price" })
    .min(0, "The Price can not be a negative number."),
  highPrice: z
    .number({ invalid_type_error: "Please enter a price" })
    .min(0, "The Price can not be a negative number."),
});

type FormData = z.infer<typeof schema>;

const CandleStickCreate = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });
  const { Create } = new CandleStickService();

  return (
    <form
      onSubmit={handleSubmit((data) => {
        Create(data.closePrice, data.openPrice, data.highPrice, data.lowPrice);
      })}
    >
      <Container
        marginTop={20}
        backgroundColor={"gray.50"}
        borderRadius={40}
        padding={20}
        paddingBottom={10}
        paddingTop={10}
      >
        <Box marginBottom={8} display={"flex"} justifyContent={"center"}>
          <Heading fontSize={25}>Candle Stick App</Heading>
        </Box>
        <FormControl>
          <FormLabel>Open Price: </FormLabel>
          <Input
            {...register("openPrice", { valueAsNumber: true })}
            step={"any"}
            type="number"
          ></Input>
          <Text color="red">{errors.openPrice?.message}</Text>
        </FormControl>
        <FormControl marginTop={5}>
          <FormLabel>Close Price: </FormLabel>
          <Input
            {...register("closePrice", { valueAsNumber: true })}
            step={"any"}
            type="number"
          ></Input>
          <Text color="red">{errors.closePrice?.message}</Text>
        </FormControl>
        <FormControl marginTop={5}>
          <FormLabel>High Price: </FormLabel>
          <Input
            {...register("highPrice", { valueAsNumber: true })}
            step={"any"}
            type="number"
          ></Input>
          <Text color="red">{errors.highPrice?.message}</Text>
        </FormControl>
        <FormControl marginTop={5}>
          <FormLabel>Low Price: </FormLabel>
          <Input
            {...register("lowPrice", { valueAsNumber: true })}
            step={"any"}
            type="number"
          ></Input>
          <Text color="red">{errors.lowPrice?.message}</Text>
        </FormControl>
        <Box marginTop={10} display={"flex"} justifyContent={"center"}>
          <Button type="submit">Create New CandleStick</Button>
        </Box>
      </Container>
    </form>
  );
};

export default CandleStickCreate;
